﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mixer.Base;
using Mixer.Base.Model.Channel;
using Mixer.Base.Model.User;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mixer.Base.UnitTests
{
    [TestClass]
    public class ChatsServiceUnitTests : UnitTestBase
    {
        public static async Task<ChannelChatModel> GetChat(MixerConnection connection)
        {
            ChannelModel channel = await ChannelsServiceUnitTests.GetChannel(connection);

            ChannelChatModel chat = await connection.Chats.GetChat(channel);

            Assert.IsNotNull(chat);
            Assert.IsTrue(chat.endpoints.Count() > 0);

            return chat;
        }

        [TestMethod]
        public void GetChat()
        {
            TestWrapper(async (MixerConnection connection) =>
            {
                ChannelChatModel chat = await ChatsServiceUnitTests.GetChat(connection);
            });
        }

        [TestMethod]
        public void GetUsers()
        {
            TestWrapper(async (MixerConnection connection) =>
            {
                ChannelModel channel = await ChannelsServiceUnitTests.GetChannel(connection);

                IEnumerable<ChatUserModel> users = await connection.Chats.GetUsers(channel);

                Assert.IsNotNull(users);

                if (users.Count() > 0)
                {
                    ChatUserModel user = await connection.Chats.GetUser(channel, users.First().userId.GetValueOrDefault());
                }
            });
        }


        [TestMethod]
        public void GetUsersProcessor()
        {
            TestWrapper(async (MixerConnection connection) =>
            {
                ChannelModel channel = await ChannelsServiceUnitTests.GetChannel(connection);

                List<ChatUserModel> users = new List<ChatUserModel>();
                await connection.Chats.GetUsers(channel, (results) =>
                {
                    foreach (ChatUserModel result in results)
                    {
                        users.Add(result);
                    }
                    return Task.FromResult(0);
                });

                Assert.IsNotNull(users);

                if (users.Count() > 0)
                {
                    ChatUserModel user = await connection.Chats.GetUser(channel, users.First().userId.GetValueOrDefault());
                }
            });
        }
    }
}
