using System.Collections.Generic;
using Bogus;
using Homework_REST.Constants.Message;
using Homework_REST.Factories;
using Homework_REST.Utils;

namespace Homework_REST.Mock.Project
{
    public class ProjectMocks
    {
        public static IEnumerable<object[]> IncorrectValues()
        {
            var moreThanMaxLength = ProjectFactory.GetProjectModel().Generate();
            moreThanMaxLength.Name = RandomUtils.GenerateString(
                Constants.ValidationConstants.Constants.RequestProjectModel.NotesMaxLength + 1);

            var serializedProject = NewtonsoftJsonSerializer.Serialize(moreThanMaxLength);
            const string typeOfError = ErrorMessage.MoreThanMaxValue;

            var missingValue = ProjectFactory.GetProjectModel().Generate();
            missingValue.Name = null;

            var serializedNullNameProject = NewtonsoftJsonSerializer.Serialize(missingValue);
            const string typeError = ErrorMessage.RequiredFieldName;

            return new List<object[]>
            {
                new object[]
                {
                    serializedProject,
                    typeOfError
                },
                new object[]
                {
                    serializedNullNameProject,
                    typeError
                }
            };
        }

        public static IEnumerable<object[]> IncorrectIdForProject()
        {
            var incorrectId = new Faker().Random.AlphaNumeric(8);
            const string missingId = null;
            const string specialSymbolId = "№*%!";

            const string projectIsNotValid = ErrorMessage.ProjectIdIsNotValid;
            const string invalidCharacters = ErrorMessage.InvalidCharacters;
            const string requiredFieldProjectId = ErrorMessage.RequiredFieldProjectId;

            return new List<object[]>
            {
                new object[]
                {
                    incorrectId,
                    projectIsNotValid
                },

                new object[]
                {
                    missingId,
                    requiredFieldProjectId
                },

                new object[]
                {
                    specialSymbolId,
                    invalidCharacters
                }
            };
        }
    }
}