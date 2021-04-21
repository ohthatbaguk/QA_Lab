using System.Collections.Generic;
using Bogus;
using Homework_REST.Constants.Message;
using Homework_REST.Factories;
using Homework_REST.Utils;

namespace Homework_REST.Mock.Suite
{
    public class SuiteMocks
    {
        public static IEnumerable<object[]> IncorrectValuesForUpdateSuite()
        {
            var moreThanMaxLength = SuiteFactory.GetSuiteModel();
            moreThanMaxLength.Name = RandomUtils.GenerateString(
                Constants.ValidationConstants.Constants.RequestProjectModel.NotesMaxLength + 1);

            var serializedSuite = NewtonsoftJsonSerializer.Serialize(moreThanMaxLength);

            return new List<object[]>
            {
                new object[]
                {
                    serializedSuite,
                    ErrorMessage.MoreThanMaxValue
                }
            };
        }

        public static IEnumerable<object[]> IncorrectValuesForAddSuite()
        {
            var moreThanMaxLength = SuiteFactory.GetSuiteModel();
            moreThanMaxLength.Name = RandomUtils.GenerateString(
                Constants.ValidationConstants.Constants.RequestProjectModel.NotesMaxLength + 1);

            var serializedSuite = NewtonsoftJsonSerializer.Serialize(moreThanMaxLength);

            var nullNameSuite = SuiteFactory.GetSuiteModel();
            nullNameSuite.Name = null;

            var serializedNullNameSuite = NewtonsoftJsonSerializer.Serialize(nullNameSuite);

            return new List<object[]>
            {
                new object[]
                {
                    serializedSuite,
                    ErrorMessage.MoreThanMaxValue
                },

                new object[]
                {
                    serializedNullNameSuite,
                    ErrorMessage.RequiredFieldName
                }
            };
        }

        public static IEnumerable<object[]> IncorrectIdForSuite()
        {
            var incorrectId = new Faker().Random.AlphaNumeric(8);
            const string missingId = null;
            const string specialSymbolId = "№*%!";

            return new List<object[]>
            {
                new object[]
                {
                    incorrectId,
                    ErrorMessage.SuiteIdIsNotValid
                },

                new object[]
                {
                    missingId,
                    ErrorMessage.RequiredFieldSuiteId
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