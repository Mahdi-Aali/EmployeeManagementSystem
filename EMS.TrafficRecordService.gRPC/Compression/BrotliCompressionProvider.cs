namespace EMS.TrafficRecordService.gRPC.Compression;

public class BrotliCompressionProvider : ICompressionProvider
{
    private CompressionLevel? _compressionLevel;

    public BrotliCompressionProvider(CompressionLevel level) => _compressionLevel = level;

    public string EncodingName => "br";

    public Stream CreateCompressionStream(Stream stream, CompressionLevel? compressionLevel)
    {
        if (_compressionLevel.HasValue)
        {
            return new BrotliStream(stream, _compressionLevel ?? compressionLevel.Value, true);
        }
        else if(!_compressionLevel.HasValue && compressionLevel.HasValue)
        {
            return new BrotliStream(stream, compressionLevel.Value, true);
        }

        return new BrotliStream(stream, CompressionLevel.Fastest, true);
    }

    public Stream CreateDecompressionStream(Stream stream)
    {
        return new BrotliStream(stream, CompressionMode.Decompress);
    }
}
