using NzbDrone.Common.Http;
using NzbDrone.Core.Configuration;
using NzbDrone.Core.Parser;
using NLog;

namespace NzbDrone.Core.Indexers.Eztv
{
    public class GenericTorrentRSS : HttpIndexerBase<GenericTorrentRSSSettings>
    {
        public override DownloadProtocol Protocol { get { return DownloadProtocol.Torrent; } }

        public GenericTorrentRSS(IHttpClient httpClient, IConfigService configService, IParsingService parsingService, Logger logger)
            : base(httpClient, configService, parsingService, logger)
        {

        }

        public override IIndexerRequestGenerator GetRequestGenerator()
        {
            return new GenericTorrentRSSRequestGenerator() { Settings = Settings };
        }

        public override IParseIndexerResponse GetParser()
        {
            return new TorrentRssParser();
        }
    }
}