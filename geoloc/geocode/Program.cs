using NGeoNames;
using NGeoNames.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace geocode
{
    class Program
    {
        static readonly IEnumerable<ExtendedGeoName> _locationNames;
        static readonly ReverseGeoCode<ExtendedGeoName> _reverseGeoCodingService;
        private static int maxdistance;

        static readonly (double Lat, double Lng) _gavlePosition;
        static readonly (double Lat, double Lng) _uppsalaPostion;

        static readonly IFormatProvider _formatProvider;
        static Program()
        {
            _locationNames = GeoFileReader.ReadExtendedGeoNames(".\\Resources\\SE.txt");
            _reverseGeoCodingService = new ReverseGeoCode<ExtendedGeoName>(_locationNames);

            _gavlePosition = (60.674622, 17.141830);
            _uppsalaPostion = (59.858562, 17.638927);
            maxdistance = 200 * 1000;
        }

        static void Main(string[] args)
        {
            // 1. Hitta de 10 närmsta platserna till Gävle (60.674622, 17.141830), sorterat på namn.
            ListGavlePostion();
            // 2. Hitta alla platser inom 200 km radie till Uppsala (59.858562, 17.638927), sorterat på avstånd.
            ListTwentyToUppsala();



            /*(double Lat, double Lng) positionGefle = (60.674622, 17.141830);
            int maxdistance = 20; 
            // 1. Hitta de 10 närmsta platserna till Gävle (60.674622, 17.141830), sorterat på namn.
            
            // 2. Hitta alla platser inom 200 km radie till Uppsala (59.858562, 17.638927), sorterat på avstånd.
            // 3. Lista x platser baserat på användarinmatning.
            _reverseGeoCodingService.RadialSearch(60.674622, 17.141830, maxdistance);

            var r = new ReverseGeoCode<ExtendedGeoName>(_locationNames);
            r.NearestNeighbourSearch(60.674622, 17.141830, 10);



            Console.WriteLine(value: $"{r}"); */
            // 3. Lista x platser baserat på användarinmatning.
            static void ListGavlePostion()
            {

                var nearestGavle = _reverseGeoCodingService.RadialSearch(_gavlePosition.Lat, _gavlePosition.Lng, 10);

                nearestGavle = nearestGavle.OrderBy(p => p.Name);

                foreach (var position in nearestGavle)
                {
                    Console.WriteLine($"{position.Name} lat: {position.Latitude} lng: {position.Longitude}  ");
                }

            }

            static void ListUserPosition()
            {
                double lat = double.Parse(args[0], _formatProvider);
                double lng = double.Parse(args[1], _formatProvider);

                var nearestUser = _reverseGeoCodingService.RadialSearch(lat, lng, 10);

                foreach (var position in nearestUser)
                {
                    var userDistance = position.DistanceTo(lat, lng);

                    Console.WriteLine($"{position} ");
                }
            }

            static void ListTwentyToUppsala()
            {
                var radiusUppsala = _reverseGeoCodingService.RadialSearch(_uppsalaPostion.Lat, _uppsalaPostion.Lng, maxdistance, 35);

                radiusUppsala = radiusUppsala.OrderBy(p => p.DistanceTo(59.858562, 17.638927));

                foreach (var postion in radiusUppsala)
                {
                    Console.WriteLine($"{postion.Name} Distance to Uppsala: {postion.DistanceTo(59.858562, 17.638927)}");
                }

            }



        }
        
    }
}
