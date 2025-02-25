﻿// Copyright (c) 2002-2019 "Neo4j,"
// Neo4j Sweden AB [http://neo4j.com]
// 
// This file is part of Neo4j.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using Neo4j.Driver.Internal.Messaging.V3;
using static Neo4j.Driver.Internal.Protocol.BoltProtocolV3MessageFormat;

namespace Neo4j.Driver.Internal.IO.MessageSerializers.V3
{
    internal class RunWithMetadataMessageSerializer : WriteOnlySerializer
    {
        public override IEnumerable<Type> WritableTypes => new[] {typeof(RunWithMetadataMessage)};

        public override void Serialize(IPackStreamWriter writer, object value)
        {
            var msg = value.CastOrThrow<RunWithMetadataMessage>();

            writer.WriteStructHeader(3, MsgRun);
            writer.Write(msg.Query.Text);
            writer.Write(msg.Query.Parameters);
            writer.Write(msg.Metadata);
        }
    }
}