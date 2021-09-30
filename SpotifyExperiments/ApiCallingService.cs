using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;

namespace SpotifyExperiments
{
    public class ApiCallingService : BackgroundService
    {
        private string token =
            "BQD20zF0fMaldX6ZvN1mTy39WiRPamNejyGyFgHd9sNDKtNW00cHK4Dvx317e9bOIRVgZ_eHPL6Yvb4kEAgNVgfJbZUDLQ5PgNgsF2ZuIpqqIONSoyG8GNPRCMvs3APzBWgCW8DxO_GlRaw_HHYeKV6SY-2Z65AqT4lN4sMEwZCSCkacClXKC17ZgHQFUZpiRecYOVSFl8UUH2mSHq3Ol0774Lg8BsKpWEO4d2kox1XfM43sqfEUx-cW_owJiyEFNpTyBz0";

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Example();
            return Task.CompletedTask;

        }
        public async void  Example()
        {
            SpotifyWebAPI api = new SpotifyWebAPI
            {
                AccessToken = token,
                TokenType = "Bearer"
            };

            var artistSeed = new List<string>() {"Steve Reich"};
            var track = await api.GetArtistsTopTracksAsync("0OdUWJ0sBjDrqHygGUXeCF","1");
            if(!track.HasError())
                Console.WriteLine(track.Tracks.First().Name);
        }
    }
}
