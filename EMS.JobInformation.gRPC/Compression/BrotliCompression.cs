using Grpc.Net.Compression;
using System.IO.Compression;

namespace EMS.JobInformation.gRPC.Compression;

public class BrotliCompression : ICompressionProvider
{
    private readonly CompressionLevel? _level;

    public BrotliCompression(CompressionLevel? level) => _level = level;

    public string EncodingName => "br";

    public Stream CreateCompressionStream(Stream stream, CompressionLevel? compressionLevel)
    {
        if (_level.HasValue)
        {
            return new BrotliStream(stream, _level ?? compressionLevel!.Value, true);
        }
        else if(!_level.HasValue && compressionLevel.HasValue)
        {
            return new BrotliStream(stream, compressionLevel.Value, true);
        }
        return new BrotliStream(stream, CompressionLevel.Fastest);
    }

    public Stream CreateDecompressionStream(Stream stream)
    {
        return new BrotliStream(stream, CompressionMode.Decompress);
    }
}
