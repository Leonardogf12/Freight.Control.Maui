#import <UIKit/UIKit.h>

NS_ASSUME_NONNULL_BEGIN

@interface DXListViewScrolledEventArgs : NSObject

@property (readonly, nonatomic) CGFloat deltaX;
@property (readonly, nonatomic) CGFloat deltaY;
@property (readonly, nonatomic) CGFloat offsetX;
@property (readonly, nonatomic) CGFloat offsetY;
@property (readonly, nonatomic) int firstVisibleItemIndex;
@property (readonly, nonatomic) int lastVisibleItemIndex;
@property (readonly, nonatomic) CGFloat viewportWidth;
@property (readonly, nonatomic) CGFloat viewportHeight;
@property (readonly, nonatomic) CGFloat extentWidth;
@property (readonly, nonatomic) CGFloat extentHeight;

-(void)set:(CGFloat)deltaX andDeltaY:(CGFloat)deltaY
             andOffsetX:(CGFloat)offsetX andOffsetY:(CGFloat)offsetY
             andFirstVisibleItemIndex:(int)firstVisibleItemIndex andLastVisibleItemIndex:(int)lastVisibleItemIndex
             andViewportWidth:(CGFloat)viewportWidth andViewportHeight:(CGFloat)viewportHeight
            andExtentWidth:(CGFloat)extentWidth andExtentHeight:(CGFloat)extentHeight;
@end

NS_ASSUME_NONNULL_END
