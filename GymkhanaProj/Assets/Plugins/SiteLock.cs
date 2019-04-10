/*
 * AntiPiracy.cs - Permits the game only to run on allowed hosts
 * Copyright (C) 2010 Justin Lloyd
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU lesser General Public License
 * along with this library.  If not, see <http://www.gnu.org/licenses/>.
 *
 */

// adapted from https://github.com/JustinLloyd/unity-anti-piracy

using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;



public class SiteLock : MonoBehaviour
{
    /// Do we permit execution from local host or local file system?
    public bool allowLocalHost;

    public string[] allowedRemoteHosts;

    public string[] allowedLocalHosts;

    public SiteLock()
    {
        allowLocalHost = true;
        allowedLocalHosts = new string[] { "localhost" };
        allowedRemoteHosts = new string[] { "crazygames.com", "gioca.re", "1001juegos.com", "speelspelletjes.nl", "onlinegame.co.id" };
    }

    public void SiteLockCheck()
    {
        if (!IsOnValidHost())
        {
            if (Debug.isDebugBuild)
            {
                Debug.Log("Failed valid remote host test, Crashing");
            }

            Crash(0);
            return;
        }
    }

    public bool IsOnValidHost()
    {
        return IsOnValidLocalHost() || IsOnValidRemoteHost();
    }

    /// Determine if the current host exists in the given list of permitted hosts.
    private bool IsValidHost(string[] hosts)
    {
        if (Debug.isDebugBuild)
        {
            StringBuilder msg = new StringBuilder();
            msg.Append("Checking against list of hosts: ");
            foreach (string url in hosts)
            {
                msg.Append(url);
                msg.Append(",");
            }

            Debug.Log(msg.ToString());
        }

        // check current host against each of the given hosts
        Regex hostRegex = new Regex(@"^(\w+)://(?<hostname>[^/]+?)(?<port>:\d+)?/");
        Match match = hostRegex.Match(Application.absoluteURL);
        if (!match.Success)
        {
            // somehow our current url is not a valid url
            return false;
        }
        String hostname = match.Groups["hostname"].Value;
        String[] splittedHost = hostname.Split("."[0]);
        foreach (string host in hosts)
        {
            if (DoesHostMatch(host, splittedHost))
            {
                return true;
            }
        }
        return false;
    }

    private bool DoesHostMatch(String allowedHost, String[] applicationHost)
    {
        String[] splitAllowed = allowedHost.Split("."[0]);

        if (applicationHost.Length < splitAllowed.Length)
        {
            return false;
        }
        for (int i = 0; i < splitAllowed.Length; i++)
        {
            String currentSplit = splitAllowed[i];
            String currentHost = applicationHost[applicationHost.Length - splitAllowed.Length + i];
            if (!currentSplit.Equals(currentHost))
            {
                return false;
            }
        }
        return true;
    }

    /// Determine if the current host is a valid local host.
    private bool IsOnValidLocalHost()
    {
        return allowLocalHost && IsValidHost(allowedLocalHosts);
    }

    /// <summary>
    /// Determine if the current host is a valid remote host.
    /// </summary>
    /// <returns>True if the game is permitted to execute from the remote host.</returns>
    private bool IsOnValidRemoteHost()
    {
        return (IsValidHost(allowedRemoteHosts));
    }

    // redirects can be prevented, so just enforce an infinite loop to crash unity
    private void Crash(int i)
    {
        Crash(i++);
    }
}
