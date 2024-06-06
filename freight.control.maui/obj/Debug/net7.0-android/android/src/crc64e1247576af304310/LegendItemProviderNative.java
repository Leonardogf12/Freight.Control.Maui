package crc64e1247576af304310;


public class LegendItemProviderNative
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.devexpress.dxcharts.LegendItemProvider
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getLegendItemCount:()I:GetGetLegendItemCountHandler:DevExpress.Android.Charts.ILegendItemProviderInvoker, DevExpress.Android.Charts\n" +
			"n_getLegendItem:(I)Lcom/devexpress/dxcharts/CustomLegendItem;:GetGetLegendItem_IHandler:DevExpress.Android.Charts.ILegendItemProviderInvoker, DevExpress.Android.Charts\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Maui.Charts.Android.Internal.LegendItemProviderNative, DevExpress.Maui.Charts", LegendItemProviderNative.class, __md_methods);
	}


	public LegendItemProviderNative ()
	{
		super ();
		if (getClass () == LegendItemProviderNative.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Charts.Android.Internal.LegendItemProviderNative, DevExpress.Maui.Charts", "", this, new java.lang.Object[] {  });
		}
	}


	public int getLegendItemCount ()
	{
		return n_getLegendItemCount ();
	}

	private native int n_getLegendItemCount ();


	public com.devexpress.dxcharts.CustomLegendItem getLegendItem (int p0)
	{
		return n_getLegendItem (p0);
	}

	private native com.devexpress.dxcharts.CustomLegendItem n_getLegendItem (int p0);

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
