﻿using System;

namespace TestClient.Wpf.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Azure MyPictures test client");
            callback(item, null);
        }
    }
}