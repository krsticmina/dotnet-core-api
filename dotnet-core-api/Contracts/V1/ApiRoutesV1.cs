namespace dotnet_core_api.Contracts.V1
{
    public static class ApiRoutesV1
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version + "/";



        public static class Categories
        {
            public const string AddCategory = Base + "categories";
            public const string DeleteCategoryById = Base + "categories/{categoryId:int}";
            public const string DeleteCategoryByName = Base + "categories/{categoryName:alpha}";
        }
    }

}
