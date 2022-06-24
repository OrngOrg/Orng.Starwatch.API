﻿namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class MetaEndpointsRoute
    {
        public const string RoutePath = "api/meta/endpoints";
    }

    public ConversionResult<RestResponse<List<string>?>> GetRestEndpoints ()
    =>  GetRestResponseSync<RestResponse<List<string>?>> (MetaEndpointsRoute.RoutePath);
}
