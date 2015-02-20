// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.TestHost;
using XmlFormattersWebSite;
using Xunit;

namespace Microsoft.AspNet.Mvc.FunctionalTests
{
    public class XmlDataContractSerializerInputFormatterTest
    {
        private readonly IServiceProvider _services = TestHelper.CreateServices(nameof(XmlFormattersWebSite));
        private readonly Action<IApplicationBuilder> _app = new Startup().Configure;

        [Fact]
        public async Task ThrowsOnInvalidInput_AndAddsToModelState()
        {
            // Arrange
            var server = TestServer.Create(_services, _app);
            var client = server.CreateClient();
            var input = "Not a valid xml document";
            var content = new StringContent(input, Encoding.UTF8, "application/xml-dcs");

            // Act
            var response = await client.PostAsync("http://localhost/Home/Index", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            var data = await response.Content.ReadAsStringAsync();
            Assert.Contains(
                string.Format(
                    "dummyObject:There was an error deserializing the object of type {0}",
                    typeof(DummyClass).FullName), 
                data);
        }
    }
}