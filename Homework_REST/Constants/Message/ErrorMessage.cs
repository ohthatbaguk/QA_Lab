namespace Homework_REST.Constants.Message
{
    public static class ErrorMessage
    {
        public const string FailedAuthentication =
            "Authentication failed: invalid or missing user/password or session cookie.";

        public const string IncorrectProjectId = "Field :project_id is not a valid or accessible project.";

        public const string RequiredFieldName = "Field :name is a required field.";

        public const string RequiredFieldProjectId = "Field :project_id is a required field.";

        public const string RequiredFieldSuiteId = "Field :suite_id is a required field.";

        public const string SuiteIdIsNotValid = "Field :suite_id is not a valid ID.";

        public const string MoreThanMaxValue = "Field :name is too long (250 characters at most).";

        public const string ProjectIdIsNotValid = "Field :project_id is not a valid ID.";

        public const string InvalidCharacters = "Invalid characters in URI";
    }
}