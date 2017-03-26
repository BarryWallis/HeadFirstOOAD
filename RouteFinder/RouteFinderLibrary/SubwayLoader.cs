using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteFinderLibrary
{
    public class SubwayLoader
    {
        /// <summary>
        /// Load the Subway line from <paramref name="textReader"/>.
        /// </summary>
        /// <param name="textReader">The input stream to read the Subway line from.</param>
        /// <returns>A Subway with the given line loaded.</returns>
        public Subway Load(TextReader textReader)
        {
            if (textReader == null)
                throw new ArgumentNullException(nameof(textReader));

            Subway subway = new Subway();
            LoadStations(subway, textReader);
            string lineName;
            while (!string.IsNullOrWhiteSpace(lineName = textReader.ReadLine()))
            {
                LoadLine(subway,textReader, lineName);
            }

            return subway;
        }

        /// <summary>
        /// Load the Stations for the <paramref name="lineName"/> into the <paramref name="subway"/> from the <paramref name="textReader"/>.
        /// </summary>
        /// <param name="subway">The Subway to load the line into.</param>
        /// <param name="textReader">THe stream to read the lines from.</param>
        /// <param name="lineName">The name of the Subway line.</param>
        private void LoadLine(Subway subway, TextReader textReader, string lineName)
        {
            if (subway == null)
                throw new ArgumentNullException(nameof(subway));
            if (textReader == null)
                throw new ArgumentNullException(nameof(textReader));
            if (string.IsNullOrWhiteSpace(lineName))
                throw new ArgumentNullException(nameof(lineName));

            string station1Name = textReader.ReadLine();
            if (string.IsNullOrWhiteSpace(station1Name))
                throw new IOException("Expected station name but found an empty line.");
            string station2Name;
            while(!string.IsNullOrWhiteSpace(station2Name = textReader.ReadLine()))
            {
                subway.AddConnection(station1Name, station2Name, lineName);
                station1Name = station2Name;
            }
        }

        /// <summary>
        /// Load the list of Station names from the <paramref name="textReader"/> into the <paramref name="subway"/>.
        /// </summary>
        /// <param name="subway">The Subway to load the Station names into.</param>
        /// <param name="textReader">The strean to read the Station names from.</param>
        private void LoadStations(Subway subway, TextReader textReader)
        {
            if (subway == null)
                throw new ArgumentNullException(nameof(subway));
            if (textReader == null)
                throw new ArgumentNullException(nameof(textReader));

            string currentLine;
            while (!string.IsNullOrWhiteSpace(currentLine = textReader.ReadLine()))
            {
                subway.AddStation(currentLine);
            }
        }
    }
}
