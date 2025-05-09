using OpenCvSharp.Internal;

namespace OpenCvSharp.ImgHash;

/// <inheritdoc />
/// <summary>
/// pHash: Slower than average_hash, but tolerant of minor modifications.
/// This algorithm can combat more variation than averageHash, for more details please refer to @cite lookslikeit
/// </summary>
// ReSharper disable once InconsistentNaming
public class PHash : ImgHashBase
{
    /// <summary>
    /// cv::Ptr&lt;T&gt;
    /// </summary>
    private Ptr? ptrObj;

    /// <summary>
    /// 
    /// </summary>
    protected PHash(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <returns></returns>
    public static PHash Create()
    {
        NativeMethods.HandleException(
            NativeMethods.img_hash_PHash_create(out var p));
        return new PHash(p);
    }
        
    /// <inheritdoc />
    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        ptrObj?.Dispose();
        ptrObj = null;
        base.DisposeManaged();
    }

    // ReSharper disable once RedundantOverriddenMember
    /// <inheritdoc />
    /// <summary>
    /// Computes pHash value of the input image
    /// </summary>
    /// <param name="inputArr">input image want to compute hash value, type should be CV_8UC4, CV_8UC3, CV_8UC1.</param>
    /// <param name="outputArr">Hash value of input, it will contain 8 uchar value</param>
    /// <returns></returns>
    public override void Compute(InputArray inputArr, OutputArray outputArr)
    {
        base.Compute(inputArr, outputArr);
    }

    internal class Ptr(IntPtr ptr) : OpenCvSharp.Ptr(ptr)
    {
        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.img_hash_Ptr_PHash_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.img_hash_Ptr_PHash_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
