// This source code is dual-licensed under the Apache License, version
// 2.0, and the Mozilla Public License, version 1.1.
//
// The APL v2.0:
//
//---------------------------------------------------------------------------
//   Copyright (C) 2007-2013 VMware, Inc.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//---------------------------------------------------------------------------
//
// The MPL v1.1:
//
//---------------------------------------------------------------------------
//  The contents of this file are subject to the Mozilla Public License
//  Version 1.1 (the "License"); you may not use this file except in
//  compliance with the License. You may obtain a copy of the License
//  at http://www.mozilla.org/MPL/
//
//  Software distributed under the License is distributed on an "AS IS"
//  basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See
//  the License for the specific language governing rights and
//  limitations under the License.
//
//  The Original Code is RabbitMQ.
//
//  The Initial Developer of the Original Code is VMware, Inc.
//  Copyright (c) 2007-2013 VMware, Inc.  All rights reserved.
//---------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;

namespace RabbitMQ.Client.Impl
{
    public abstract class FileProperties : ContentHeaderBase, IFileProperties
    {
        public abstract string ContentType { get; set; }
        public abstract string ContentEncoding { get; set; }
        public abstract IDictionary Headers { get; set; }
        public abstract byte Priority { get; set; }
        public abstract string ReplyTo { get; set; }
        public abstract string MessageId { get; set; }
        public abstract string Filename { get; set; }
        public abstract AmqpTimestamp Timestamp { get; set; }
        public abstract string ClusterId { get; set; }

        public abstract void ClearContentType();
        public abstract void ClearContentEncoding();
        public abstract void ClearHeaders();
        public abstract void ClearPriority();
        public abstract void ClearReplyTo();
        public abstract void ClearMessageId();
        public abstract void ClearFilename();
        public abstract void ClearTimestamp();
        public abstract void ClearClusterId();

        public abstract bool IsContentTypePresent();
        public abstract bool IsContentEncodingPresent();
        public abstract bool IsHeadersPresent();
        public abstract bool IsPriorityPresent();
        public abstract bool IsReplyToPresent();
        public abstract bool IsMessageIdPresent();
        public abstract bool IsFilenamePresent();
        public abstract bool IsTimestampPresent();
        public abstract bool IsClusterIdPresent();

        public override object Clone()
        {
            FileProperties clone = MemberwiseClone() as FileProperties;
            if (IsHeadersPresent())
            {
                clone.Headers = new Dictionary<string, object>();
                foreach (DictionaryEntry entry in Headers)
                    clone.Headers[entry.Key] = entry.Value;
            }

            return clone;
        }
    }
}
