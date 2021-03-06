﻿/* Copyright 2010 10gen Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace MongoDB.DriverUnitTests.Builders {
    [TestFixture]
    public class UpdateBuilderTests {
        [Test]
        public void TestAddToSet() {
            var update = Update.AddToSet("name", "abc");
            var expected = "{ \"$addToSet\" : { \"name\" : \"abc\" } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestAddToSetEach() {
            var update = Update.AddToSetEach("name", "abc", "def");
            var expected = "{ \"$addToSet\" : { \"name\" : { \"$each\" : [\"abc\", \"def\"] } } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestIncDouble() {
            var update = Update.Inc("name", 1.1);
            var expected = "{ \"$inc\" : { \"name\" : 1.1 } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestIncInt() {
            var update = Update.Inc("name", 1);
            var expected = "{ \"$inc\" : { \"name\" : 1 } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestIncLong() {
            var update = Update.Inc("name", 1L);
            var expected = "{ \"$inc\" : { \"name\" : 1 } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestPopFirst() {
            var update = Update.PopFirst("name");
            var expected = "{ \"$pop\" : { \"name\" : 1 } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestPopLast() {
            var update = Update.PopLast("name");
            var expected = "{ \"$pop\" : { \"name\" : -1 } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestPull() {
            var update = Update.Pull("name", "abc");
            var expected = "{ \"$pull\" : { \"name\" : \"abc\" } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestPullAll() {
            var update = Update.PullAll("name", "abc", "def");
            var expected = "{ \"$pullAll\" : { \"name\" : [\"abc\", \"def\"] } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestPush() {
            var update = Update.Push("name", "abc");
            var expected = "{ \"$push\" : { \"name\" : \"abc\" } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestPushAll() {
            var update = Update.PushAll("name", "abc", "def");
            var expected = "{ \"$pushAll\" : { \"name\" : [\"abc\", \"def\"] } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestSet() {
            var update = Update.Set("name", "abc");
            var expected = "{ \"$set\" : { \"name\" : \"abc\" } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestUnset() {
            var update = Update.Unset("name");
            var expected = "{ \"$unset\" : { \"name\" : 1 } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestAddToSetTwice() {
            var update = Update.AddToSet("a", 1).AddToSet("b", 2);
            var expected = "{ \"$addToSet\" : { \"a\" : 1, \"b\" : 2 } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestAddToSetEachTwice() {
            var update = Update.AddToSetEach("a", 1, 2).AddToSetEach("b", 3, 4);
            var expected = "{ \"$addToSet\" : { \"a\" : { \"$each\" : [1, 2] }, \"b\" : { \"$each\" : [3, 4] } } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestIncDoubleTwice() {
            var update = Update.Inc("x", 1.1).Inc("y", 2.2);
            var expected = "{ \"$inc\" : { \"x\" : 1.1, \"y\" : 2.2 } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestIncIntTwice() {
            var update = Update.Inc("x", 1).Inc("y", 2);
            var expected = "{ \"$inc\" : { \"x\" : 1, \"y\" : 2 } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestIncLongTwice() {
            var update = Update.Inc("x", 1L).Inc("y", 2L);
            var expected = "{ \"$inc\" : { \"x\" : 1, \"y\" : 2 } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestPopFirstTwice() {
            var update = Update.PopFirst("a").PopFirst("b");
            var expected = "{ \"$pop\" : { \"a\" : 1, \"b\" : 1 } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestPopLastTwice() {
            var update = Update.PopLast("a").PopLast("b");
            var expected = "{ \"$pop\" : { \"a\" : -1, \"b\" : -1 } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestPullTwice() {
            var update = Update.Pull("a", 1).Pull("b", 2);
            var expected = "{ \"$pull\" : { \"a\" : 1, \"b\" : 2 } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestPullAllTwice() {
            var update = Update.PullAll("a", 1, 2).PullAll("b", 3, 4);
            var expected = "{ \"$pullAll\" : { \"a\" : [1, 2], \"b\" : [3, 4] } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestPushTwice() {
            var update = Update.Push("a", 1).Push("b", 2);
            var expected = "{ \"$push\" : { \"a\" : 1, \"b\" : 2 } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestPushAllTwice() {
            var update = Update.PushAll("a", 1, 2).PushAll("b", 3, 4);
            var expected = "{ \"$pushAll\" : { \"a\" : [1, 2], \"b\" : [3, 4] } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestSetTwice() {
            var update = Update.Set("a", 1).Set("b", 2);
            var expected = "{ \"$set\" : { \"a\" : 1, \"b\" : 2 } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestUnsetTwice() {
            var update = Update.Unset("a").Unset("b");
            var expected = "{ \"$unset\" : { \"a\" : 1, \"b\" : 1 } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestSetThenAddToSet() {
            var update = Update.Set("x", 1).AddToSet("name", "abc");
            var expected = "{ \"$set\" : { \"x\" : 1 }, \"$addToSet\" : { \"name\" : \"abc\" } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestSetThenAddToSetEach() {
            var update = Update.Set("x", 1).AddToSetEach("name", "abc", "def");
            var expected = "{ \"$set\" : { \"x\" : 1 }, \"$addToSet\" : { \"name\" : { \"$each\" : [\"abc\", \"def\"] } } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestSetThenIncDouble() {
            var update = Update.Set("x", 1).Inc("name", 1.1);
            var expected = "{ \"$set\" : { \"x\" : 1 }, \"$inc\" : { \"name\" : 1.1 } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestSetThenIncInt() {
            var update = Update.Set("x", 1).Inc("name", 1);
            var expected = "{ \"$set\" : { \"x\" : 1 }, \"$inc\" : { \"name\" : 1 } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestSetThenIncLong() {
            var update = Update.Set("x", 1).Inc("name", 1L);
            var expected = "{ \"$set\" : { \"x\" : 1 }, \"$inc\" : { \"name\" : 1 } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestSetThenPopFirst() {
            var update = Update.Set("x", 1).PopFirst("name");
            var expected = "{ \"$set\" : { \"x\" : 1 }, \"$pop\" : { \"name\" : 1 } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestSetThenPopLast() {
            var update = Update.Set("x", 1).PopLast("name");
            var expected = "{ \"$set\" : { \"x\" : 1 }, \"$pop\" : { \"name\" : -1 } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestSetThenPull() {
            var update = Update.Set("x", 1).Pull("name", "abc");
            var expected = "{ \"$set\" : { \"x\" : 1 }, \"$pull\" : { \"name\" : \"abc\" } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestSetThenPullAll() {
            var update = Update.Set("x", 1).PullAll("name", "abc", "def");
            var expected = "{ \"$set\" : { \"x\" : 1 }, \"$pullAll\" : { \"name\" : [\"abc\", \"def\"] } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestSetThenPush() {
            var update = Update.Set("x", 1).Push("name", "abc");
            var expected = "{ \"$set\" : { \"x\" : 1 }, \"$push\" : { \"name\" : \"abc\" } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestSetThenPushAll() {
            var update = Update.Set("x", 1).PushAll("name", "abc", "def");
            var expected = "{ \"$set\" : { \"x\" : 1 }, \"$pushAll\" : { \"name\" : [\"abc\", \"def\"] } }";
            Assert.AreEqual(expected, update.ToJson());
        }

        [Test]
        public void TestSetThenUnset() {
            var update = Update.Set("x", 1).Unset("name");
            var expected = "{ \"$set\" : { \"x\" : 1 }, \"$unset\" : { \"name\" : 1 } }";
            Assert.AreEqual(expected, update.ToJson());
        }
    }
}
