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

        public static class Comments
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

        public static class Locations
        {
            public const string LocationsEndpoint = ApiEndpoint + "/locations";
            public const string LocationsRatingEndpoint = LocationsEndpoint + "/ratings";
            public const string LocationsSuggestionEndpoint = LocationsEndpoint + "/suggestions";
            public const string SearchLocationsEndpoint = ApiEndpoint + "/locations/searching";
            public const string LocationEndpoint = ApiEndpoint + "/locations/{id}";
            public const string TrendLocationEndpoint = ApiEndpoint + "/locations/trend";
            public const string TopYearLocationEndpoint = ApiEndpoint + "/locations/top-year";
            public const string LocationCommentEndpoint = LocationEndpoint + "/comments";

            public const string CityLocationEndpoint = ApiEndpoint + "/{city}/locations";
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
            public const string AIChatMessageEndpoint = MessagesEndpoint + "/chat-agent";
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
            public const string UserUserNameEndpoint = UsersEndpoint + "/{username}";
            public const string UserForgetPassEndpoint = ApiEndpoint + "/users/password-forget";
            public const string UserFavLocationEndpoint = UserUserNameEndpoint + "/fav-locations";
            public const string UserFriendImagesEndpoint = UserUserNameEndpoint + "/images";
            public const string UserFriendStatusesEndpoint = UserUserNameEndpoint + "/status";

            public const string UserEndpoint = UsersEndpoint + "/{id}/info";
        }
    }
}
