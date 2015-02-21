// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Cors;
using Microsoft.AspNet.Cors.Core;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc.Core;
using Microsoft.AspNet.Mvc.Logging;
using Microsoft.AspNet.Mvc.Routing;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet.WebUtilities;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.Framework.OptionsModel;

namespace Microsoft.AspNet.Mvc
{
    public class CorsAuthorizationFilter : IAsyncAuthorizationFilter
    {
        private readonly CorsPolicy _corsPolicy;
        private bool _originsValidated;

        public CorsAuthorizationFilter(CorsPolicy corsPolicy)
        {
            _corsPolicy = corsPolicy;
        }

        /// <inheritdoc />
        public Task<CorsPolicy> GetCorsPolicyAsync(ICorsRequestContext context)
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
                var policy = _corsPolicy;
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

        private static void AddCommaSeparatedValuesToCollection(string commaSeparatedValues, IList<string> collection)
        {
            string[] values = commaSeparatedValues.Split(',');
            for (int i = 0; i < values.Length; i++)
            {
                string value = values[i].Trim();
                if (!String.IsNullOrEmpty(value))
                {
                    collection.Add(value);
                }
            }
        }
    }
}
