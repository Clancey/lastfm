﻿using IF.Lastfm.Core.Api.Helpers;
using IF.Lastfm.Core.Objects;
using System;
using System.Threading.Tasks;
using IF.Lastfm.Core.Api.Commands.Library;

namespace IF.Lastfm.Core.Api
{
    public class LibraryApi : ILibraryApi
    {
        public ILastAuth Auth { get; private set; }

        public async Task<PageResponse<LastTrack>> GetTracks(string username, string artist, string album, DateTimeOffset since, int pagenumber = 0, int count = LastFm.DefaultPageLength)
        {
            var command = new GetTracksCommand(Auth, username, artist, album, since)
                          {
                              Page = pagenumber,
                              Count = count
                          };

            return await command.ExecuteAsync();
        }
    }
}