// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Cors.Core;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc.Core;
using Microsoft.AspNet.Mvc.Logging;
using Microsoft.AspNet.Mvc.Routing;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet.WebUtilities;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;

namespace Microsoft.AspNet.Mvc
{
    public class EnableCorsAttribute : Attribute, IAsyncAuthorizationFilter, ICorsPolicyProvider
    {
        private ICorsPolicy _corsPolicy = new CorsPolicy();
        private bool _originsValidated;

        /// <summary>
        /// Gets the headers that the resource might use and can be exposed.
        /// </summary>
        public IList<string> ExposedHeaders
        {
            get
            {
                return _corsPolicy.ExposedHeaders;
            }
        }

        /// <summary>
        /// Gets the headers that are supported by the resource.
        /// </summary>
        public IList<string> Headers
        {
            get
            {
                return _corsPolicy.Headers;
            }
        }

        /// <summary>
        /// Gets the methods that are supported by the resource.
        /// </summary>
        public IList<string> Methods
        {
            get
            {
                return _corsPolicy.Methods;
            }
        }

        /// <summary>
        /// Gets the origins that are allowed to access the resource.
        /// </summary>
        public IList<string> Origins
        {
            get
            {
                return _corsPolicy.Origins;
            }
        }

        /// <summary>
        /// Gets or sets the number of seconds the results of a preflight request can be cached.
        /// </summary>
        public long PreflightMaxAge
        {
            get
            {
                return _corsPolicy.PreflightMaxAge ?? -1;
            }
            set
            {
                _corsPolicy.PreflightMaxAge = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the resource supports user credentials in the request.
        /// </summary>
        public bool SupportsCredentials
        {
            get
            {
                return _corsPolicy.SupportsCredentials;
            }
            set
            {
                _corsPolicy.SupportsCredentials = value;
            }
        }

        /// <inheritdoc />
        public Task<ICorsPolicy> GetCorsPolicyAsync(ICorsRequestContext context)
        {
            if (!_originsValidated)
            {
                ValidateOrigins(_corsPolicy.Origins);
                _originsValidated = true;
            }

            return Task.FromResult(_corsPolicy);
        }

        public async Task OnAuthorizationAsync([NotNull] AuthorizationContext context)
        {
            var corsContext = new CorsRequestContext(context.HttpContext);

            if (corsContext.IsCorsRequest)
            {
                var engine = context.HttpContext.RequestServices.GetRequiredService<ICorsEngine>();
                var policy = await GetCorsPolicyAsync(corsContext);
                var result = engine.EvaluatePolicy(corsContext, policy);
                if (corsContext.IsPreflight)
                {
                    var statusCode = 0;
                    if (result.IsValid)
                    {
                        statusCode = StatusCodes.Status200OK;
                        WriteCorsHeaders(context.HttpContext, result);
                    }
                    else
                    {
                        // TODO: write out the errors as well.
                        statusCode = StatusCodes.Status400BadRequest;
                    }

                    // If this was a preflight, there is no need to run anything else.
                    // ShortCircuit.
                    context.Result = new HttpStatusCodeResult(statusCode);
                    await Task.FromResult(true);
                }
                else
                {
                    if (result.IsValid)
                    {
                        WriteCorsHeaders(context.HttpContext, result);
                    }
                    else
                    {
                        // TODO: write out the errors as well.
                        context.Result = new HttpStatusCodeResult(StatusCodes.Status400BadRequest);
                    }
                }
            }
        }

        private static void WriteCorsHeaders(HttpContext context, ICorsResult result)
        {
            foreach (var header in result.GetResponseHeaders())
            {
                context.Response.Headers.Set(header.Key, header.Value);
            }
        }

        private static void ValidateOrigins(IList<string> origins)
        {
            foreach (string origin in origins)
            {
                if (String.IsNullOrEmpty(origin))
                {
                    throw new InvalidOperationException("SRResources.OriginCannotBeNullOrEmpty");
                }

                if (origin.EndsWith("/", StringComparison.Ordinal))
                {
                    throw new InvalidOperationException(
                        String.Format(
                            CultureInfo.CurrentCulture,
                            "SRResources.OriginCannotEndWithSlash",
                            origin));
                }

                if (!Uri.IsWellFormedUriString(origin, UriKind.Absolute))
                {
                    throw new InvalidOperationException(
                        String.Format(
                            CultureInfo.CurrentCulture,
                            "SRResources.OriginNotWellFormed",
                            origin));
                }

                Uri originUri = new Uri(origin);
                if ((!String.IsNullOrEmpty(originUri.AbsolutePath) && !String.Equals(originUri.AbsolutePath, "/", StringComparison.Ordinal)) ||
                    !String.IsNullOrEmpty(originUri.Query) ||
                    !String.IsNullOrEmpty(originUri.Fragment))
                {
                    throw new InvalidOperationException(
                        String.Format(
                            CultureInfo.CurrentCulture,
                            "SRResources.OriginMustNotContainPathQueryOrFragment",
                            origin));
                }
            }
        }
    }
}
