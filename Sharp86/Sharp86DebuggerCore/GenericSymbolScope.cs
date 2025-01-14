﻿/*
Sharp86 - 8086 Emulator
Copyright (C) 2017-2018 Topten Software.

Sharp86 is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Sharp86 is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Sharp86.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp86
{
    public class GenericSymbolScope : ISymbolScope
    {
        public Symbol ResolveSymbol(string name)
        {
            Symbol sym;
            if (_symbols.TryGetValue(name, out sym))
                return sym;
            return null;
        }

        public void RegisterSymbol(string name, Func<object> callback)
        {
            _symbols.Add(name, new CallbackSymbol(callback));
        }

        //RnD
        Dictionary<string, Symbol> _symbols
            = new Dictionary<string, Symbol>(StringComparer.CurrentCultureIgnoreCase);
          //= new Dictionary<string, Symbol>(StringComparer.InvariantCultureIgnoreCase);
    }
}
