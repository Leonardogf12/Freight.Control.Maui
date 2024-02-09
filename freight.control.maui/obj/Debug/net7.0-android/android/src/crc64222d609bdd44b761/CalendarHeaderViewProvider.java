package crc64222d609bdd44b761;


public class CalendarHeaderViewProvider
	extends crc64222d609bdd44b761.HeaderViewProvider
	implements
		mono.android.IGCUserPeer,
		com.devexpress.editors.pickers.providers.HeaderViewProvider
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_update:(Landroid/view/View;IIILcom/devexpress/editors/pickers/CalendarViewStates;)V:GetUpdate_Landroid_view_View_IIILcom_devexpress_editors_pickers_CalendarViewStates_Handler:DevExpress.Android.Editors.Pickers.Providers.IHeaderViewProviderInvoker, DevExpress.Android.Editors\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Maui.Editors.Internal.CalendarHeaderViewProvider, DevExpress.Maui.Editors", CalendarHeaderViewProvider.class, __md_methods);
	}


	public CalendarHeaderViewProvider ()
	{
		super ();
		if (getClass () == CalendarHeaderViewProvider.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Editors.Internal.CalendarHeaderViewProvider, DevExpress.Maui.Editors", "", this, new java.lang.Object[] {  });
		}
	}


	public void update (android.view.View p0, int p1, int p2, int p3, com.devexpress.editors.pickers.CalendarViewStates p4)
	{
		n_update (p0, p1, p2, p3, p4);
	}

	private native void n_update (android.view.View p0, int p1, int p2, int p3, com.devexpress.editors.pickers.CalendarViewStates p4);

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
