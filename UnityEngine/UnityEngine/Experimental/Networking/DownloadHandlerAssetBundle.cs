﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.Experimental.Networking.DownloadHandlerAssetBundle
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8FF7A2C-E4EE-4232-AB17-3FCABEC16496
// Assembly location: C:\Users\Blake\sandbox\unity\test-project\Library\UnityAssemblies\UnityEngine.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine.Experimental.Networking
{
  /// <summary>
  ///   <para>A DownloadHandler subclass specialized for downloading AssetBundles.</para>
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public sealed class DownloadHandlerAssetBundle : DownloadHandler
  {
    /// <summary>
    ///   <para>Returns the downloaded AssetBundle, or null. (Read Only)</para>
    /// </summary>
    public AssetBundle assetBundle { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Standard constructor for non-cached asset bundles.</para>
    /// </summary>
    /// <param name="url">The nominal (pre-redirect) URL at which the asset bundle is located.</param>
    /// <param name="crc">A checksum to compare to the downloaded data for integrity checking, or zero to skip integrity checking.</param>
    public DownloadHandlerAssetBundle(string url, uint crc)
    {
      this.InternalCreateWebStream(url, crc);
    }

    /// <summary>
    ///   <para>Simple versioned constructor. Caches downloaded asset bundles.</para>
    /// </summary>
    /// <param name="url">The nominal (pre-redirect) URL at which the asset bundle is located.</param>
    /// <param name="crc">A checksum to compare to the downloaded data for integrity checking, or zero to skip integrity checking.</param>
    /// <param name="version">Current version number of the asset bundle at url. Increment to redownload.</param>
    public DownloadHandlerAssetBundle(string url, uint version, uint crc)
    {
      Hash128 hash = new Hash128(0U, 0U, 0U, version);
      this.InternalCreateWebStream(url, hash, crc);
    }

    /// <summary>
    ///   <para>Versioned constructor. Caches downloaded asset bundles.</para>
    /// </summary>
    /// <param name="url">The nominal (pre-redirect) URL at which the asset bundle is located.</param>
    /// <param name="crc">A checksum to compare to the downloaded data for integrity checking, or zero to skip integrity checking.</param>
    /// <param name="hash">A hash object defining the version of the asset bundle.</param>
    public DownloadHandlerAssetBundle(string url, Hash128 hash, uint crc)
    {
      this.InternalCreateWebStream(url, hash, crc);
    }

    /// <summary>
    ///   <para>Not implemented. Throws &lt;a href="http:msdn.microsoft.comen-uslibrarysystem.notsupportedexception"&gt;NotSupportedException&lt;a&gt;.</para>
    /// </summary>
    /// <returns>
    ///   <para>Not implemented.</para>
    /// </returns>
    protected override byte[] GetData()
    {
      throw new NotSupportedException("Raw data access is not supported for asset bundles");
    }

    /// <summary>
    ///   <para>Not implemented. Throws &lt;a href="http:msdn.microsoft.comen-uslibrarysystem.notsupportedexception"&gt;NotSupportedException&lt;a&gt;.</para>
    /// </summary>
    /// <returns>
    ///   <para>Not implemented.</para>
    /// </returns>
    protected override string GetText()
    {
      throw new NotSupportedException("String access is not supported for asset bundles");
    }

    /// <summary>
    ///   <para>Returns the downloaded AssetBundle, or null.</para>
    /// </summary>
    /// <param name="www">A finished UnityWebRequest object with DownloadHandlerAssetBundle attached.</param>
    /// <returns>
    ///   <para>The same as DownloadHandlerAssetBundle.assetBundle</para>
    /// </returns>
    public static AssetBundle GetContent(UnityWebRequest www)
    {
      return DownloadHandler.GetCheckedDownloader<DownloadHandlerAssetBundle>(www).assetBundle;
    }
  }
}
