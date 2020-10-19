using System;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Users.Common.Models;

namespace Users.Common.Services
{
    public class PasswordService : IPasswordService
    {
        private const string _letters = "abcdefghijklmnopqrstuvwxyz";
        private const string _numbers = "1234567890";
        private const string _special = Constants.Passwords.SpecialCharacters;

        private readonly Random _randomizer;

        public PasswordService()
        {
            _randomizer = new Random();
        }

        public string GeneratePassword(uint length, uint capitalLetters = 1, uint numbers = 1, uint specialChars = 1)
        {
            if (capitalLetters + numbers + specialChars > length)
                throw new ArgumentOutOfRangeException("Capital, numbers and special characters");

            var buffer = new char[length];

            for (var i = 0; i < buffer.Length; i++)
            {
                var currentCharacter = GetRandomCharacter(_letters);

                if (i < capitalLetters)
                {
                    currentCharacter = char.ToUpper(currentCharacter);
                }
                else if (i < length - numbers - specialChars)
                {
                    currentCharacter = GetRandomCharacter(_special);
                }
                else if (i < length - numbers)
                {
                    currentCharacter = GetRandomCharacter(_numbers);
                }


                buffer[i] = currentCharacter;
            }


            return new string(buffer);

        }

        public IServiceResponse ValidatePassword(string password, uint length, uint capitalLetters = 1, uint numbers = 1, uint specialChars = 1)
        {
            throw new NotImplementedException();
        }


        private char GetRandomCharacter(string input)
        {

            var position = new Random().Next(0, input.Length);
            return input[position];
        }

    }
}
