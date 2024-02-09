package mono.com.devexpress.dxlistview.core;


public class ItemsViewAdapterListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.devexpress.dxlistview.core.ItemsViewAdapterListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_viewDidUpdate:(Landroid/view/View;I)V:GetViewDidUpdate_Landroid_view_View_IHandler:DevExpress.Android.CollectionView.Core.IItemsViewAdapterListenerInvoker, DevExpress.Android.CollectionView\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Android.CollectionView.Core.IItemsViewAdapterListenerImplementor, DevExpress.Android.CollectionView", ItemsViewAdapterListenerImplementor.class, __md_methods);
	}


	public ItemsViewAdapterListenerImplementor ()
	{
		super ();
		if (getClass () == ItemsViewAdapterListenerImplementor.class) {
			mono.android.TypeManager.Activate ("DevExpress.Android.CollectionView.Core.IItemsViewAdapterListenerImplementor, DevExpress.Android.CollectionView", "", this, new java.lang.Object[] {  });
		}
	}


	public void viewDidUpdate (android.view.View p0, int p1)
	{
		n_viewDidUpdate (p0, p1);
	}

	private native void n_viewDidUpdate (android.view.View p0, int p1);

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
