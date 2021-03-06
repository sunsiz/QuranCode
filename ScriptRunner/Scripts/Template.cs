using System;
using System.Collections.Generic;
using Model;

public class MyScript : IScriptRunner
{
    private bool MyMethod(Client client)
    {
        if (client == null) return false;
        if (client.Book == null) return false;
        if (client.Book.Verses == null) return false;
        if (client.FoundVerses == null) client.FoundVerses = new List<Verse>();

        client.FoundVerses.Clear();
        foreach (Verse verse in client.Book.Verses)
        {
            long value = client.CalculateValue(verse);
            if (Numbers.IsPrime(value)) // user condition
            {
                client.FoundVerses.Add(verse);
            }
        }
        return true; // to close Script window and show client.FoundVerses
    }

    // QuranCode USE ONLY
    /// <summary>
    /// Run implements IScriptRunner interface to be invoked by QuranCode application.
    /// </summary>
    /// <param name="args">Must pass a Client object here.</param>
    /// <returns>Return bool to indicate success or not.</returns>
    public object Run(object[] args)
    {
        if (args.Length >= 1)
        {
            Client client = args[0] as Client;
            if (client != null)
            {
                return MyMethod(client);
            }
        }
        return false;
    }
}
