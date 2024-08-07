﻿/*
 * Copyright (C) 2009 Google Inc.
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

namespace PhoneNumbers
{
    public class PhoneNumberMatch
    {
        public int Start { get; }
        public int Length => RawString.Length;
        public string RawString { get; }
        public PhoneNumber Number { get; }

#if NET6_0_OR_GREATER
        public PhoneNumberMatch(int start, string? rawString, PhoneNumber? number)
#else
        public PhoneNumberMatch(int start, string rawString, PhoneNumber number)
#endif
        {
            if (start < 0)
                throw new ArgumentException("Start index must be >= 0.");
            if (rawString == null || number == null)
                throw new ArgumentNullException();
            Start = start;
            RawString = rawString;
            Number = number;
        }

#if NET6_0_OR_GREATER
        public override bool Equals(object? obj)
#else
        public override bool Equals(object obj)
#endif
        {
            if (this == obj)
                return true;
            var p = (obj as PhoneNumberMatch);
            return p != null && RawString == p.RawString && Start == p.Start && Number.Equals(p.Number);
        }

        public override int GetHashCode()
        {
            var hash = GetType().GetHashCode();
            hash ^= Start.GetHashCode();
            hash ^= RawString.GetHashCode();
            hash ^= Number.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return "PhoneNumberMatch [" + Start + "," + Length + ") " + RawString;
        }
    }
}
