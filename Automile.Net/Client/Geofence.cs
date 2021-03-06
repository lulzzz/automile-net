﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public partial class AutomileClient
    {
        /// <summary>
        /// Get all geofences belonging to all vehicles
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GeofenceModel> GetGeofences()
        {
            var response = client.GetAsync("/v1/resourceowner/geofence").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<GeofenceModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get the details about a specific geofence
        /// </summary>
        /// <param name="geofenceId"></param>
        /// <returns></returns>
        public GeofenceModel GetGeofenceById(int geofenceId)
        {
            var response = client.GetAsync($"/v1/resourceowner/geofence/{geofenceId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<GeofenceModel>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Creates a new vehicle and returns the model for the newly created vehicle
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public GeofenceModel CreateGeofence(GeofenceCreateModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync("/v1/resourceowner/geofence", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            var urlToCreatedGeofence = response.Headers.GetValues("Location").First();
            var geofenceModelResponse = client.GetAsync(urlToCreatedGeofence).Result;
            geofenceModelResponse.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<GeofenceModel>(geofenceModelResponse.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Edit geofence
        /// </summary>
        /// <param name="geofenceId"></param>
        /// <param name="model"></param>
        public void EditGeofence(int geofenceId, GeofenceEditModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PutAsync($"/v1/resourceowner/geofence/{geofenceId}", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        }

        /// <summary>
        /// Deletes the geofence
        /// </summary>
        /// <param name="geofenceId"></param>
        public void DeleteGeofence(int geofenceId)
        {
            var response = client.DeleteAsync($"/v1/resourceowner/geofence/{geofenceId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        }

    }
}
