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
            var moreThanMaxLength = SuiteFactory.GetSuiteModel().Generate();
            moreThanMaxLength.Name = RandomUtils.GenerateString(
                Constants.ValidationConstants.Constants.RequestProjectModel.NotesMaxLength + 1);

            var serializedSuite = NewtonsoftJsonSerializer.Serialize(moreThanMaxLength);
            const string typeOfError = ErrorMessage.MoreThanMaxValue;


            return new List<object[]>
            {
                new object[]
                {
                    serializedSuite,
                    typeOfError
                }
            };
        }

        public static IEnumerable<object[]> IncorrectValuesForAddSuite()
        {
            var moreThanMaxLength = SuiteFactory.GetSuiteModel().Generate();
            moreThanMaxLength.Name = RandomUtils.GenerateString(
                Constants.ValidationConstants.Constants.RequestProjectModel.NotesMaxLength + 1);

            var serializedSuite = NewtonsoftJsonSerializer.Serialize(moreThanMaxLength);
            const string moreThanMax = ErrorMessage.MoreThanMaxValue;

            var nullNameSuite = SuiteFactory.GetSuiteModel().Generate();
            nullNameSuite.Name = null;

            var serializedNullNameSuite = NewtonsoftJsonSerializer.Serialize(nullNameSuite);
            const string requiredField = ErrorMessage.RequiredFieldName;


            return new List<object[]>
            {
                new object[]
                {
                    serializedSuite,
                    moreThanMax
                },

                new object[]
                {
                    serializedNullNameSuite,
                    requiredField
                }
            };
        }

        public static IEnumerable<object[]> IncorrectIdForSuite()
        {
            var incorrectId = new Faker().Random.AlphaNumeric(8);
            const string missingId = null;
            const string specialSymbolId = "№*%!";

            const string suiteIsNotValid = ErrorMessage.SuiteIdIsNotValid;
            const string invalidCharacters = ErrorMessage.InvalidCharacters;
            const string requiredFieldSuiteId = ErrorMessage.RequiredFieldSuiteId;

            return new List<object[]>
            {
                new object[]
                {
                    incorrectId,
                    suiteIsNotValid
                },

                new object[]
                {
                    missingId,
                    requiredFieldSuiteId
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