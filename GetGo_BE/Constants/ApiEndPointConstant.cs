namespace GetGo_BE.Constants
{
    public class ApiEndPointConstant
    {
        public const string RootEndPoint = "/api";
        public const string ApiVersion = "/v1";
        public const string ApiEndpoint = RootEndPoint + ApiVersion;

        public static class Authentication
        {
            public const string SignInEndpoint = ApiEndpoint + "/sign-in";
            public const string SignUpEndpoint = ApiEndpoint + "/sign-up";
        }

        public static class Category
        {
            public const string CategoriesEndpoint = ApiEndpoint + "/categorys";
            public const string CategoryEndpoint = ApiEndpoint + "/categorys/{id}";
        }

        public static class Comment
        {
            public const string CommentsEndpoint = ApiEndpoint + "/comments";
            public const string CommentEndpoint = ApiEndpoint + "/comments/{id}";
        }

        public static class Feedback
        {
            public const string FeedbacksEndpoint = ApiEndpoint + "/feedbacks";
            public const string FeedbackEndpoint = ApiEndpoint + "/feedbacks/{id}";
        }

        public static class Image
        {
            public const string ImagesEndpoint = ApiEndpoint + "/images";
            public const string ImageEndpoint = ApiEndpoint + "/images/{id}";
            public const string UserImageEndpoint = ApiEndpoint + "/images/user/{userId}";
        }

        public static class Location
        {
            public const string LocationsEndpoint = ApiEndpoint + "/locations";
            public const string SearchLocationsEndpoint = ApiEndpoint + "/locations/searching";
            public const string LocationEndpoint = ApiEndpoint + "/locations/{id}";
            public const string TrendLocationEndpoint = ApiEndpoint + "/locations/trend";
            public const string TopYearLocationEndpoint = ApiEndpoint + "/locations/top-year";
            public const string LocationCommentEndpoint = LocationEndpoint + "/comments";
        }

        public static class Map
        {
            public const string MapsEndpoint = ApiEndpoint + "/maps";
            public const string MapEndpoint = ApiEndpoint + "/maps/{id}";
            public const string UserMapsEndpoint = ApiEndpoint + "/maps/user/{userId}";
        }

        public static class Message
        {
            public const string MessagesEndpoint = ApiEndpoint + "/messages";
            public const string MessageEndpoint = ApiEndpoint + "/messages/{id}";
            public const string DialogMessagesEndpoint = ApiEndpoint + "/messages/dialog";
        }

        public static class Status
        {
            public const string StatusesEndpoint = ApiEndpoint + "/statuses";
            public const string StatusEndpoint = ApiEndpoint + "/statuses/{id}";
            public const string StatusReactionEndpoint = ApiEndpoint + "/statuses/{id}/reactions";
            public const string UserStatusEndpoint = ApiEndpoint + "/statuses/user/{userId}";
        }

        public static class User
        {
            public const string UsersEndpoint = ApiEndpoint + "/users";
            public const string UserForgetPassEndpoint = ApiEndpoint + "/users/password-forget";
            public const string UserEndpoint = ApiEndpoint + "/users/{id}";
            public const string UserFavLocationEndpoint = UserEndpoint + "/fav-locations";
            public const string UserFriendImagesEndpoint = UserEndpoint + "/images";
            public const string UserFriendStatusesEndpoint = UserEndpoint + "/status";
        }
    }
}
