// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See full license at the bottom of this file.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

/// <summary>
/// ContinuationManager is used to detect if the most recent activation was due
/// to a continuation such as the WebAuthenticationBroker
/// </summary>
public class ContinuationManager
{
    IContinuationActivatedEventArgs args = null;
    bool handled = false;
    Guid id = Guid.Empty;

    /// <summary>
    /// Sets the ContinuationArgs for this instance. Using default Frame of current Window
    /// Should be called by the main activation handling code in App.xaml.cs
    /// </summary>
    /// <param name="args">The activation args</param>
    internal void Continue(IContinuationActivatedEventArgs args)
    {
        Continue(args, Window.Current.Content as Frame);
    }

    /// <summary>
    /// Sets the ContinuationArgs for this instance. Should be called by the main activation
    /// handling code in App.xaml.cs
    /// </summary>
    /// <param name="args">The activation args</param>
    /// <param name="rootFrame">The frame control that contains the current page</param>
    internal void Continue(IContinuationActivatedEventArgs args, Frame rootFrame)
    {
        if (args == null)
            throw new ArgumentNullException("args");

        if (this.args != null && !handled)
            throw new InvalidOperationException("Can't set args more than once");

        this.args = args;
        this.id = Guid.NewGuid();

        if (rootFrame == null)
            return;

        var webPage = rootFrame.Content as IWebAuthenticationContinuable;
        if (webPage != null)
        {
            webPage.ContinueWebAuthentication(args as WebAuthenticationBrokerContinuationEventArgs);
        }
    }

    /// <summary>
    /// Retrieves the continuation args, if they have not already been retrieved, and 
    /// prevents further retrieval via this property (to avoid accidentla double-usage)
    /// </summary>
    public IContinuationActivatedEventArgs ContinuationArgs
    {
        get
        {
            return args;
        }
    }

    /// <summary>
    /// Unique identifier for this particular continuation. Most useful for components that 
    /// retrieve the continuation data via <see cref="GetContinuationArgs"/> and need
    /// to perform their own replay check
    /// </summary>
    public Guid Id { get { return id; } }

}

/// <summary>
/// Implement this interface if your page invokes the web authentication
/// broker
/// </summary>
interface IWebAuthenticationContinuable
{
    /// <summary>
    /// This method is invoked when the web authentication broker returns
    /// with the authentication result
    /// </summary>
    /// <param name="args">Activated event args object that contains returned authentication token</param>
    void ContinueWebAuthentication(WebAuthenticationBrokerContinuationEventArgs args);
}

//********************************************************* 
// 
//O365-WinPhone-Connect, https://github.com/OfficeDev/O365-WinPhone-Connect
//
//Copyright (c) Microsoft Corporation
//All rights reserved. 
// 
// MIT License:
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// ""Software""), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:

// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 
//********************************************************* 

