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

        public static class Posts
        {
            public const string AddPost = Base + "posts";
            public const string DeletePostById = Base + "posts/{postId:int}";
            public const string GetPostById = Base + "posts/{postId:int}";
            public const string UpdatePost = Base + "posts/{postId:int}";
        }
    }

}
