﻿// ---------------------------------------------------------------------------------- 
// Microsoft Developer & Platform Evangelism 
//  
// Copyright (c) Microsoft Corporation. All rights reserved. 
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,  
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES  
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
// ---------------------------------------------------------------------------------- 
// The example companies, organizations, products, domain names, 
// e-mail addresses, logos, people, places, and events depicted 
// herein are fictitious.  No association with any real company, 
// organization, product, domain name, email address, logo, person, 
// places, or events is intended or should be inferred. 
// ---------------------------------------------------------------------------------- 


namespace MyPictures.Web.Tests
{
    using System.Web;
    using System.Web.Routing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class WebApiApplicationTests
    {
        [TestMethod]
        public void ShouldMapPicturesGetEndpoint()
        {
            var routeData = this.GetRouteDataWithMockContext("~/api/pictures", "GET");

            Assert.AreEqual("pictures", routeData.Values["controller"]);
            Assert.AreEqual(null, routeData.Values["action"]);
        }

        [TestMethod]
        public void ShouldMapPicturesGetOneEndpoint()
        {
            var routeData = this.GetRouteDataWithMockContext("~/api/pictures/pic1", "GET");

            Assert.AreEqual("pictures", routeData.Values["controller"]);
            Assert.AreEqual(null, routeData.Values["action"]);
            Assert.AreEqual("pic1", routeData.Values["id"]);
        }

        [TestMethod]
        public void ShouldMapPicturesPostEndpoint()
        {
            var routeData = this.GetRouteDataWithMockContext("~/api/pictures", "POST");

            Assert.AreEqual("pictures", routeData.Values["controller"]);
            Assert.AreEqual(null, routeData.Values["action"]);
        }

        [TestMethod]
        public void ShouldMapPicturesDeleteEndpoint()
        {
            var routeData = this.GetRouteDataWithMockContext("~/api/pictures", "DELETE");

            Assert.AreEqual("pictures", routeData.Values["controller"]);
            Assert.AreEqual(null, routeData.Values["action"]);
        }

        [TestMethod]
        public void ShouldMapTagsGetEndpoint()
        {
            var routeData = this.GetRouteDataWithMockContext("~/api/tags", "GET");

            Assert.AreEqual("tags", routeData.Values["controller"]);
            Assert.AreEqual(null, routeData.Values["action"]);
        }

        [TestMethod]
        public void ShouldMapTagsGetOneEndpoint()
        {
            var routeData = this.GetRouteDataWithMockContext("~/api/tags/tag1", "GET");

            Assert.AreEqual("tags", routeData.Values["controller"]);
            Assert.AreEqual(null, routeData.Values["action"]);
            Assert.AreEqual("tag1", routeData.Values["id"]);
        }

        [TestMethod]
        public void ShouldMapTagsPicturesEndpoint()
        {
            var routeData = this.GetRouteDataWithMockContext("~/api/tags/tag1/pictures", "GET");

            Assert.AreEqual("tags", routeData.Values["controller"]);
            Assert.AreEqual("pictures", routeData.Values["action"]);
            Assert.AreEqual("tag1", routeData.Values["name"]);
        }

        private RouteData GetRouteDataWithMockContext(string route, string httpMethod) 
        {
            var routes = new RouteCollection();
            WebApiApplication.RegisterRoutes(routes);
            var mockContext = new Mock<HttpContextBase>();

            mockContext.Setup(x => x.Request.AppRelativeCurrentExecutionFilePath).Returns(route);
            mockContext.Setup(x => x.Request.HttpMethod).Returns(httpMethod);
            return routes.GetRouteData(mockContext.Object);
        }
    }
}
