﻿namespace Twitch.Base.Services.NewAPI
{
    /// <summary>
    /// API wrapper for all New Twitch API services
    /// </summary>
    public class NewTwitchAPIServices
    {
        /// <summary>
        /// APIs for Bits interaction.
        /// </summary>
        public BitsService Bits { get; private set; }

        /// <summary>
        /// APIs for Clips interaction.
        /// </summary>
        public ClipsService Clips { get; private set; }

        /// <summary>
        /// APIs for Games interaction.
        /// </summary>
        public GamesService Games { get; private set; }

        /// <summary>
        /// APIs for Streams interaction.
        /// </summary>
        public StreamsService Streams { get; private set; }

        /// <summary>
        /// APIs for Subscriptions interaction.
        /// </summary>
        public SubscriptionsService Subscriptions { get; private set; }

        /// <summary>
        /// APIs for Tags interaction.
        /// </summary>
        public TagsService Tags { get; private set; }

        /// <summary>
        /// APIs for User interaction.
        /// </summary>
        public UsersService Users { get; private set; }

        /// <summary>
        /// Creates a new instance of the NewTwitchAPIServices class with the specified connection.
        /// </summary>
        /// <param name="connection">The Twitch connection</param>
        public NewTwitchAPIServices(TwitchConnection connection)
        {
            this.Bits = new BitsService(connection);
            this.Clips = new ClipsService(connection);
            this.Games = new GamesService(connection);
            this.Streams = new StreamsService(connection);
            this.Subscriptions = new SubscriptionsService(connection);
            this.Tags = new TagsService(connection);
            this.Users = new UsersService(connection);
        }
    }
}
