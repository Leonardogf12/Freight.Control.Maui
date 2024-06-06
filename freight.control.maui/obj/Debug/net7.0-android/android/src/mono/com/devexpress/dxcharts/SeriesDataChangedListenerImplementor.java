package mono.com.devexpress.dxcharts;


public class SeriesDataChangedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.devexpress.dxcharts.SeriesDataChangedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onItemAdded:()V:GetOnItemAddedHandler:DevExpress.Android.Charts.ISeriesDataChangedListenerInvoker, DevExpress.Android.Charts\n" +
			"n_onItemChanged:(I)V:GetOnItemChanged_IHandler:DevExpress.Android.Charts.ISeriesDataChangedListenerInvoker, DevExpress.Android.Charts\n" +
			"n_onItemInserted:(I)V:GetOnItemInserted_IHandler:DevExpress.Android.Charts.ISeriesDataChangedListenerInvoker, DevExpress.Android.Charts\n" +
			"n_onItemRemoved:(I)V:GetOnItemRemoved_IHandler:DevExpress.Android.Charts.ISeriesDataChangedListenerInvoker, DevExpress.Android.Charts\n" +
			"n_onItemsAdded:(I)V:GetOnItemsAdded_IHandler:DevExpress.Android.Charts.ISeriesDataChangedListenerInvoker, DevExpress.Android.Charts\n" +
			"n_onItemsChanged:(II)V:GetOnItemsChanged_IIHandler:DevExpress.Android.Charts.ISeriesDataChangedListenerInvoker, DevExpress.Android.Charts\n" +
			"n_onItemsInserted:(II)V:GetOnItemsInserted_IIHandler:DevExpress.Android.Charts.ISeriesDataChangedListenerInvoker, DevExpress.Android.Charts\n" +
			"n_onItemsRemoved:(II)V:GetOnItemsRemoved_IIHandler:DevExpress.Android.Charts.ISeriesDataChangedListenerInvoker, DevExpress.Android.Charts\n" +
			"n_onReloaded:()V:GetOnReloadedHandler:DevExpress.Android.Charts.ISeriesDataChangedListenerInvoker, DevExpress.Android.Charts\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Android.Charts.ISeriesDataChangedListenerImplementor, DevExpress.Android.Charts", SeriesDataChangedListenerImplementor.class, __md_methods);
	}


	public SeriesDataChangedListenerImplementor ()
	{
		super ();
		if (getClass () == SeriesDataChangedListenerImplementor.class) {
			mono.android.TypeManager.Activate ("DevExpress.Android.Charts.ISeriesDataChangedListenerImplementor, DevExpress.Android.Charts", "", this, new java.lang.Object[] {  });
		}
	}


	public void onItemAdded ()
	{
		n_onItemAdded ();
	}

	private native void n_onItemAdded ();


	public void onItemChanged (int p0)
	{
		n_onItemChanged (p0);
	}

	private native void n_onItemChanged (int p0);


	public void onItemInserted (int p0)
	{
		n_onItemInserted (p0);
	}

	private native void n_onItemInserted (int p0);


	public void onItemRemoved (int p0)
	{
		n_onItemRemoved (p0);
	}

	private native void n_onItemRemoved (int p0);


	public void onItemsAdded (int p0)
	{
		n_onItemsAdded (p0);
	}

	private native void n_onItemsAdded (int p0);


	public void onItemsChanged (int p0, int p1)
	{
		n_onItemsChanged (p0, p1);
	}

	private native void n_onItemsChanged (int p0, int p1);


	public void onItemsInserted (int p0, int p1)
	{
		n_onItemsInserted (p0, p1);
	}

	private native void n_onItemsInserted (int p0, int p1);


	public void onItemsRemoved (int p0, int p1)
	{
		n_onItemsRemoved (p0, p1);
	}

	private native void n_onItemsRemoved (int p0, int p1);


	public void onReloaded ()
	{
		n_onReloaded ();
	}

	private native void n_onReloaded ();

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
