/*
 * Switcheroo - The incremental-search task switcher for Windows.
 * http://www.switcheroo.io/
 * Copyright 2009, 2010 James Sulak
 * Copyright 2014 Regin Larsen
 * 
 * Switcheroo is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * Switcheroo is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with Switcheroo.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Shapes;
using System.Xml.Linq;
using Switcheroo.Core.Matchers;

namespace Switcheroo
{
    public class XamlHighlighter
    {
        public IEnumerable<Inline> Highlight(IEnumerable<StringPart> stringParts)
        {
            if (stringParts == null)
            {
                yield return new Run();
                yield break;
            }

            foreach (var stringPart in stringParts)
            {
                var run = new Run(stringPart.Value);
                if (stringPart.IsMatch)
                {
                    yield return new Bold(run);
                }
                else
                {
                    yield return run;
                }
            }
        }
    }
}