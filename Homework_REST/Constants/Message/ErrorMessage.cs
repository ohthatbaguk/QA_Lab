namespace Homework_REST.Constants.Message
{
    public static class ErrorMessage
    {
        public const string FailedAuthentication = "Authentication failed: invalid or missing user/password or session cookie.";

        public const string InvalidProjectId = "Field :project_id is not a valid or accessible project.";

        public const string RequiredField = "Field :name is a required field.";

        public const string InvalidSuiteId = "Field :suite_id is not a valid test suite.";

        public const string MoreThanMaxValue = "Field :name is too long (250 characters at most).";
    }
}