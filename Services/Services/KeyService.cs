using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstraction;

namespace BusinessLayer.Services
{
    public class KeyService : IKeyService
    {
        private readonly char[] characters;
        private IDictionary<int, char> DigitMap { get; set; }
        private IDictionary<char, int> CharMap { get; set; }
        private readonly int baseLength;

        public KeyService(IConfiguration configuration)
        {
            var charInput = configuration["Settings:ScaleChars"].ToCharArray(); // NOTE: no need to check the character set as it is an app setting - fail if anything goes wrong

            characters = charInput;
            DigitMap = BuildMapping();
            CharMap = DigitMap.Reverse();
            baseLength = characters.Length;
        }

        /// <summary>
        /// Provides records's id converted to a key
        /// </summary>
        /// <param name="id">Id of a record</param>
        /// <returns></returns>
        public Task<string> GetKeyAsync(int id)
        {
            var multiples = ConvertToBase(id);
            var key = GetStringRepresentation(multiples);

            return Task.FromResult(key);
        }

        /// <summary>
        /// Provides integer representation of a key
        /// </summary>
        /// <param name="key">Key to convert</param>
        /// <returns>Integer representation of the key</returns>
        public Task<int> GetIdAsync(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException();
            }

            var sum = 0;
            var pwr = 0;

            foreach (var ch in key)
            {
                if (!CharMap.ContainsKey(ch))
                {
                    throw new ArgumentException();
                }

                sum += CharMap[ch] * (int)Math.Pow(baseLength, pwr);
                pwr++;
            }

            return Task.FromResult(sum);
        }

        /// <summary>
        /// Converts an integer to into the custom-base 
        /// </summary>
        /// <param name="number">Number to convert</param>
        /// <returns>List of multiples</returns>
        private IEnumerable<int> ConvertToBase(int number)
        {
            var multiples = new List<int>();

            while (number > 0)
            {
                var mod = number % baseLength;
                multiples.Add(mod);
                number /= baseLength;
            }
            
            return multiples;
        }

        /// <summary>
        /// Gets string representation of the multiples
        /// </summary>
        /// <param name="multiples">multiples in the base</param>
        /// <returns>String representation of the multiples (key)</returns>
        private string GetStringRepresentation(IEnumerable<int> multiples)
        {
            if (multiples is null)
            {
                throw new ArgumentNullException(nameof(multiples));
            }

            var rep = string.Empty;

            foreach(var m in multiples)
            {
                rep += characters[m];
            }

            return rep;
        }

        /// <summary>
        /// Creates a mapping using set of characters provided
        /// e.g.: a -> 0; b -> 1
        /// </summary>
        /// <returns>A dictionary map </returns>
        private IDictionary<int, char> BuildMapping()
        {
            var map = new Dictionary<int, char>();

            for (int i = 0; i < characters.Length; i++)
            {
                map.Add(i, characters[i]);
            }

            return map;
        }
    }
}
