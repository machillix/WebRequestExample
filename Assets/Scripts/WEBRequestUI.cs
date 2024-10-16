/*****************************************************************************
 * File        : WEBRequestUI.cs
 * Version     : 1.0
 * Author      : Toni Westerlund
 * Copyright   : Toni Westerlund
 * Licence     : MIT-Licence
 * 
 * Copyright (c) 2024
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in 
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 * 
 *****************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

/// <summary>
/// UserInputs
/// </summary>
public class WEBRequestUI : MonoBehaviour
{

    /***************************************************************************
    *                             MEMBERS
    ***************************************************************************/

    /// <summary>
    /// Server Url
    /// </summary>
    [SerializeField]private TMP_Text serverUrl;
    
    /// <summary>
    /// Message
    /// </summary>
    [SerializeField]private TMP_Text message;

    /// <summary>
    /// Return Value
    /// </summary>
    [SerializeField]private TMP_Text returnValue;

    /***************************************************************************
    *                          FROM BASE CLASS
    ***************************************************************************/

    /***************************************************************************
    *                          UNITY MESSAGES
    ***************************************************************************/

    /***************************************************************************
    *                          PUBLIC METHODS
    ***************************************************************************/

    /// <summary>
    /// Send Post Request
    /// </summary>
    public void SendPostRequest()
    {

        // TODO : Add Error Handling
        string url = serverUrl.text;
        string message = this.message.text;
        url = url.Remove(url.Length-1);
        
        message = message.Remove(message.Length-1);
        
        // { "uid": "1234567890", "message": "HelloWorld" }
        string jsonMessage = 
        "{ \"uid\": \""+SystemInfo.deviceUniqueIdentifier+
        "\", \"message\": \""+message+"\" }";


        StartCoroutine(RestCommunication.SendPostRequest(
            url ,jsonMessage ,UpdateReturnValueText));
    }

    /// <summary>
    /// Send Get Request
    /// </summary>
    public void SendGetRequest()
    {
        // TODO : Add Error Handling
        string url = serverUrl.text;
        string message = this.message.text;
        url = url.Remove(url.Length-1);
        message = message.Remove(message.Length-1);

        StartCoroutine(RestCommunication.SendPostRequest(
            url ,message ,UpdateReturnValueText));
    }

    /// <summary>
    /// Update Return Value Text
    /// </summary>
    /// <param name="text">return value text</param>
    private void UpdateReturnValueText(string text)
    {
        returnValue.text = text;
    }

    /***************************************************************************
    *                          PRIVATE METHODS
    ***************************************************************************/

}
