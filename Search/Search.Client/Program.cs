﻿using CommandLine;
using Search.Client.Options;
using Search.Client.Services;
using Search.Common.Services;
using System;
using System.Collections.Generic;

namespace Search.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<IndexOptions, SearchOptions>(args)
                          .MapResult<IndexOptions, SearchOptions, object>(Index, Search, Error);
        }

        static object Index(IndexOptions options)
        {
            var recipe = RecipeFactory.CreateFrom(options.Url);
            var client = SearchClientFactory.CreateClient(options);

            var response = client.Index(recipe);

            Console.WriteLine(response.DebugInformation);

            //var result = client.Search(search => search.QueryOnQueryString(options.Query)
            //                                           .Sort(order => order.Descending(field => field.Rating))
            //                                           .Take(20));

            //Fråga mot specifikt fält
            //var result = client.Count(search => search.Query(
            //                                      query => query.Match(
            //                                          match => match.Field(field => field.Author)
            //                                                        .Query("Per Morberg"))));

            var result = client.Search(search => search.QueryOnQueryString("categories:\"Bönor\""));

            return 0;
        }

        static object Search(SearchOptions options)
        {
            var client = SearchClientFactory.CreateClient(options);

            // Hitta recept med fisk

            return 0;
        }

        static object Error(IEnumerable<Error> errors)
        {
            foreach (var error in errors)
            {
                Console.WriteLine(error.ToString());
            }

            return 1;
        }
    }
}
