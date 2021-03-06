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
using System.Reflection;

namespace MongoDB.Bson.DefaultSerializer.Conventions {
    public interface IIdMemberConvention {
        string FindIdMember(Type type); 
    }

    public class NamedIdMemberConvention : IIdMemberConvention {
        public string Name { get; private set; }

        public NamedIdMemberConvention(
            string name
        ) {
            Name = name;
        }

        public string FindIdMember(
            Type type
        ) {
            var memberInfo = type.GetMember(Name).SingleOrDefault(x => x.MemberType == MemberTypes.Field || x.MemberType == MemberTypes.Property);
            return (memberInfo != null) ? Name : null;
        }
    }
}
