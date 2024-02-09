package crc64a3de810b23927aec;


public class ViewProvider
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.devexpress.dxlistview.core.DXListItemViewProvider,
		com.devexpress.dxlistview.swipes.DXSwipeItemsViewProvider
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getItemCount:()I:GetGetItemCountHandler:DevExpress.Android.CollectionView.Core.IDXListItemViewProviderInvoker, DevExpress.Android.CollectionView\n" +
			"n_checkView:(Landroid/view/View;I)Z:GetCheckView_Landroid_view_View_IHandler:DevExpress.Android.CollectionView.Core.IDXListItemViewProviderInvoker, DevExpress.Android.CollectionView\n" +
			"n_getViewByIndex:(I)Landroid/view/View;:GetGetViewByIndex_IHandler:DevExpress.Android.CollectionView.Core.IDXListItemViewProviderInvoker, DevExpress.Android.CollectionView\n" +
			"n_getViewTypeByIndex:(I)I:GetGetViewTypeByIndex_IHandler:DevExpress.Android.CollectionView.Core.IDXListItemViewProviderInvoker, DevExpress.Android.CollectionView\n" +
			"n_recycleView:(Landroid/view/View;II)V:GetRecycleView_Landroid_view_View_IIHandler:DevExpress.Android.CollectionView.Core.IDXListItemViewProviderInvoker, DevExpress.Android.CollectionView\n" +
			"n_updateView:(Landroid/view/View;I)V:GetUpdateView_Landroid_view_View_IHandler:DevExpress.Android.CollectionView.Core.IDXListItemViewProviderInvoker, DevExpress.Android.CollectionView\n" +
			"n_getAllowFullSwipe:(ILcom/devexpress/dxlistview/swipes/DXSwipeGroup;)Ljava/lang/Boolean;:GetGetAllowFullSwipe_ILcom_devexpress_dxlistview_swipes_DXSwipeGroup_Handler:DevExpress.Android.CollectionView.Swipes.IDXSwipeItemsViewProviderInvoker, DevExpress.Android.CollectionView\n" +
			"n_getSwipeViewColors:(ILcom/devexpress/dxlistview/swipes/DXSwipeGroup;)Ljava/util/List;:GetGetSwipeViewColors_ILcom_devexpress_dxlistview_swipes_DXSwipeGroup_Handler:DevExpress.Android.CollectionView.Swipes.IDXSwipeItemsViewProviderInvoker, DevExpress.Android.CollectionView\n" +
			"n_getSwipeViewSizes:(ILcom/devexpress/dxlistview/swipes/DXSwipeGroup;)Ljava/util/List;:GetGetSwipeViewSizes_ILcom_devexpress_dxlistview_swipes_DXSwipeGroup_Handler:DevExpress.Android.CollectionView.Swipes.IDXSwipeItemsViewProviderInvoker, DevExpress.Android.CollectionView\n" +
			"n_getSwipeViews:(ILcom/devexpress/dxlistview/swipes/DXSwipeGroup;)Ljava/util/List;:GetGetSwipeViews_ILcom_devexpress_dxlistview_swipes_DXSwipeGroup_Handler:DevExpress.Android.CollectionView.Swipes.IDXSwipeItemsViewProviderInvoker, DevExpress.Android.CollectionView\n" +
			"n_isSwipeAllowed:(ILcom/devexpress/dxlistview/swipes/DXSwipeGroup;)Ljava/lang/Boolean;:GetIsSwipeAllowed_ILcom_devexpress_dxlistview_swipes_DXSwipeGroup_Handler:DevExpress.Android.CollectionView.Swipes.IDXSwipeItemsViewProviderInvoker, DevExpress.Android.CollectionView\n" +
			"n_recycleViews:(ILcom/devexpress/dxlistview/swipes/DXSwipeGroup;Ljava/util/List;)V:GetRecycleViews_ILcom_devexpress_dxlistview_swipes_DXSwipeGroup_Ljava_util_List_Handler:DevExpress.Android.CollectionView.Swipes.IDXSwipeItemsViewProviderInvoker, DevExpress.Android.CollectionView\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Maui.CollectionView.Android.Internal.ViewProvider, DevExpress.Maui.CollectionView", ViewProvider.class, __md_methods);
	}


	public ViewProvider ()
	{
		super ();
		if (getClass () == ViewProvider.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.CollectionView.Android.Internal.ViewProvider, DevExpress.Maui.CollectionView", "", this, new java.lang.Object[] {  });
		}
	}


	public int getItemCount ()
	{
		return n_getItemCount ();
	}

	private native int n_getItemCount ();


	public boolean checkView (android.view.View p0, int p1)
	{
		return n_checkView (p0, p1);
	}

	private native boolean n_checkView (android.view.View p0, int p1);


	public android.view.View getViewByIndex (int p0)
	{
		return n_getViewByIndex (p0);
	}

	private native android.view.View n_getViewByIndex (int p0);


	public int getViewTypeByIndex (int p0)
	{
		return n_getViewTypeByIndex (p0);
	}

	private native int n_getViewTypeByIndex (int p0);


	public void recycleView (android.view.View p0, int p1, int p2)
	{
		n_recycleView (p0, p1, p2);
	}

	private native void n_recycleView (android.view.View p0, int p1, int p2);


	public void updateView (android.view.View p0, int p1)
	{
		n_updateView (p0, p1);
	}

	private native void n_updateView (android.view.View p0, int p1);


	public java.lang.Boolean getAllowFullSwipe (int p0, com.devexpress.dxlistview.swipes.DXSwipeGroup p1)
	{
		return n_getAllowFullSwipe (p0, p1);
	}

	private native java.lang.Boolean n_getAllowFullSwipe (int p0, com.devexpress.dxlistview.swipes.DXSwipeGroup p1);


	public java.util.List getSwipeViewColors (int p0, com.devexpress.dxlistview.swipes.DXSwipeGroup p1)
	{
		return n_getSwipeViewColors (p0, p1);
	}

	private native java.util.List n_getSwipeViewColors (int p0, com.devexpress.dxlistview.swipes.DXSwipeGroup p1);


	public java.util.List getSwipeViewSizes (int p0, com.devexpress.dxlistview.swipes.DXSwipeGroup p1)
	{
		return n_getSwipeViewSizes (p0, p1);
	}

	private native java.util.List n_getSwipeViewSizes (int p0, com.devexpress.dxlistview.swipes.DXSwipeGroup p1);


	public java.util.List getSwipeViews (int p0, com.devexpress.dxlistview.swipes.DXSwipeGroup p1)
	{
		return n_getSwipeViews (p0, p1);
	}

	private native java.util.List n_getSwipeViews (int p0, com.devexpress.dxlistview.swipes.DXSwipeGroup p1);


	public java.lang.Boolean isSwipeAllowed (int p0, com.devexpress.dxlistview.swipes.DXSwipeGroup p1)
	{
		return n_isSwipeAllowed (p0, p1);
	}

	private native java.lang.Boolean n_isSwipeAllowed (int p0, com.devexpress.dxlistview.swipes.DXSwipeGroup p1);


	public void recycleViews (int p0, com.devexpress.dxlistview.swipes.DXSwipeGroup p1, java.util.List p2)
	{
		n_recycleViews (p0, p1, p2);
	}

	private native void n_recycleViews (int p0, com.devexpress.dxlistview.swipes.DXSwipeGroup p1, java.util.List p2);

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
