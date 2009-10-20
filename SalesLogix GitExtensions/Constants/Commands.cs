/* 

    Git Extensions for SalesLogix
    Copyright (C) 2009  Customer FX Corporation - http://customerfx.com/

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.

    Contact Information:
    
    Ryan Farley 
    Customer FX Corporation
    http://customerfx.com/
    2324 University Avenue West, Suite 115
    Saint Paul, Minnesota 55114
    Tel: 651.646.7777  Fax: 651.846.5185
    
    This copyright must remain intact
    
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FX.SalesLogix.Modules.GitExtensions.Constants
{
    public class Commands
    {
        public const string GitExtensions = "cmd://GitExtensionsModule/GitExtensions";
        public const string Commit = "cmd://GitExtensionsModule/GitCommit";
        public const string Push = "cmd://GitExtensionsModule/GitPush";
        public const string Pull = "cmd://GitExtensionsModule/GitPull";
        public const string Settings = "cmd://GitExtensionsModule/GitSettings";
        public const string Browse = "cmd://GitExtensionsModule/GitBrowse";
        public const string Stash = "cmd://GitExtensionsModule/GitStash";
        public const string Add = "cmd://GitExtensionsModule/GitAdd";
        public const string Branch = "cmd://GitExtensionsModule/GitBranch";
        public const string Checkout = "cmd://GitExtensionsModule/GitCheckout";
        public const string Merge = "cmd://GitExtensionsModule/GitMerge";
        public const string ViewChanges = "cmd://GitExtensionsModule/GitViewChanges";
        public const string About = "cmd://GitExtensionsModule/About";
        public const string Bash = "cmd://GitExtensionsModule/GitBash";
    }
}
