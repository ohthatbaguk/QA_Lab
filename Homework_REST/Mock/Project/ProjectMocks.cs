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
            var moreThanMaxLength = ProjectFactory.GetProjectModel();
            moreThanMaxLength.Name = RandomUtils.GenerateString(
                Constants.ValidationConstants.Constants.RequestProjectModel.NotesMaxLength + 1);

            var serializedProject = NewtonsoftJsonSerializer.Serialize(moreThanMaxLength);

            var missingValue = ProjectFactory.GetProjectModel();
            missingValue.Name = null;

            var serializedNullNameProject = NewtonsoftJsonSerializer.Serialize(missingValue);

            return new List<object[]>
            {
                new object[]
                {
                    serializedProject,
                    ErrorMessage.MoreThanMaxValue
                },
                new object[]
                {
                    serializedNullNameProject,
                    ErrorMessage.RequiredFieldName
                }
            };
        }

        public static IEnumerable<object[]> IncorrectIdForProject()
        {
            var incorrectId = new Faker().Random.AlphaNumeric(8);
            const string missingId = null;
            const string specialSymbolId = "№*%!";

            return new List<object[]>
            {
                new object[]
                {
                    incorrectId,
                    ErrorMessage.ProjectIdIsNotValid
                },

                new object[]
                {
                    missingId,
                    ErrorMessage.RequiredFieldProjectId
                },

                new object[]
                {
                    specialSymbolId,
                    ErrorMessage.InvalidCharacters
                }
            };
        }
    }
}