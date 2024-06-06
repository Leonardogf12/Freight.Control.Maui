package crc64e1247576af304310;


public class PointCustomColorizer
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.devexpress.dxcharts.CustomPointColorizer,
		com.devexpress.dxcharts.PointColorizer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getLegendItemProvider:()Lcom/devexpress/dxcharts/LegendItemProvider;:GetGetLegendItemProviderHandler:DevExpress.Android.Charts.ICustomPointColorizerInvoker, DevExpress.Android.Charts\n" +
			"n_getColor:(Lcom/devexpress/dxcharts/ColoredPointInfo;)I:GetGetColor_Lcom_devexpress_dxcharts_ColoredPointInfo_Handler:DevExpress.Android.Charts.ICustomPointColorizerInvoker, DevExpress.Android.Charts\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Maui.Charts.Android.Internal.PointCustomColorizer, DevExpress.Maui.Charts", PointCustomColorizer.class, __md_methods);
	}


	public PointCustomColorizer ()
	{
		super ();
		if (getClass () == PointCustomColorizer.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Charts.Android.Internal.PointCustomColorizer, DevExpress.Maui.Charts", "", this, new java.lang.Object[] {  });
		}
	}


	public com.devexpress.dxcharts.LegendItemProvider getLegendItemProvider ()
	{
		return n_getLegendItemProvider ();
	}

	private native com.devexpress.dxcharts.LegendItemProvider n_getLegendItemProvider ();


	public int getColor (com.devexpress.dxcharts.ColoredPointInfo p0)
	{
		return n_getColor (p0);
	}

	private native int n_getColor (com.devexpress.dxcharts.ColoredPointInfo p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
