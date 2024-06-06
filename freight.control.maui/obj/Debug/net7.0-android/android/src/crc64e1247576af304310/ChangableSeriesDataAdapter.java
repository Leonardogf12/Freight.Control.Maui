package crc64e1247576af304310;


public abstract class ChangableSeriesDataAdapter
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.devexpress.dxcharts.ChangeableSeriesData
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_addChangedListener:(Lcom/devexpress/dxcharts/SeriesDataChangedListener;)V:GetAddChangedListener_Lcom_devexpress_dxcharts_SeriesDataChangedListener_Handler:DevExpress.Android.Charts.IChangeableSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"n_removeChangedListener:(Lcom/devexpress/dxcharts/SeriesDataChangedListener;)V:GetRemoveChangedListener_Lcom_devexpress_dxcharts_SeriesDataChangedListener_Handler:DevExpress.Android.Charts.IChangeableSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Maui.Charts.Android.Internal.ChangableSeriesDataAdapter, DevExpress.Maui.Charts", ChangableSeriesDataAdapter.class, __md_methods);
	}


	public ChangableSeriesDataAdapter ()
	{
		super ();
		if (getClass () == ChangableSeriesDataAdapter.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Charts.Android.Internal.ChangableSeriesDataAdapter, DevExpress.Maui.Charts", "", this, new java.lang.Object[] {  });
		}
	}


	public void addChangedListener (com.devexpress.dxcharts.SeriesDataChangedListener p0)
	{
		n_addChangedListener (p0);
	}

	private native void n_addChangedListener (com.devexpress.dxcharts.SeriesDataChangedListener p0);


	public void removeChangedListener (com.devexpress.dxcharts.SeriesDataChangedListener p0)
	{
		n_removeChangedListener (p0);
	}

	private native void n_removeChangedListener (com.devexpress.dxcharts.SeriesDataChangedListener p0);

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
