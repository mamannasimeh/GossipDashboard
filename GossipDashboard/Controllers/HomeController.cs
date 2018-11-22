using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GossipDashboard.Models;
using System.IO;
using System.Text;
using GossipDashboard.Helper;
using GossipDashboard.Repository;
using System.Timers;
using System.Text.RegularExpressions;

namespace GossipDashboard.Controllers
{
    public class HomeController : Controller
    {
        private HtmlNode result;

        public HomeController()
        {
            //Timer aTimer = new Timer();
            //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            //aTimer.Interval = 60000;
            //aTimer.Enabled = true;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            CreateIndex();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateIndex()
        {
            string path = "";
            path = ControllerContext.HttpContext.Server.MapPath("~");
            PostManagement postManagement = new PostManagement(path);

            PostRepository repo = new PostRepository();

            //ایجاد پست ها
            repo.CreatePost();

            //ایجاد صفحه اصلی
            CreateIndexPage(path, postManagement);

            //ایجاد صفحه کتگوری ها
            PostController postCtr = new PostController();
            postCtr.CreateAllCategory(path);

            return View("Index");
        }

        public ActionResult GetTextFromHtml()
        {
            //            var txt = "'" +
            //"<p style=''text-align: right;''><img class=''image_btn img-responsive-news'' style=''margin: 0px auto; display: block;'' title=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' src=''http://cdn.bartarinha.ir/files/fa/news/1397/8/24/1876020_308.jpg'' alt=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' width=''550'' height=''586'' align=''''></p>" +
            //"<p style=''text-align: right;''><img class=''image_btn img-responsive-news'' style=''margin: 0px auto; display: block;'' title=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' src=''http://cdn.bartarinha.ir/files/fa/news/1397/8/24/1876019_361.jpg'' alt=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' width=''550'' height=''277'' align=''''></p>" +
            //"<p style=''text-align: right;''>اگر در این چند روز در فضای مجازی گشتی زده بزنید خواهید دید که کاربران به شدت از «خانم یایا» و «لس آنجلس- تهران» ناراضی هستد. بیشتر کاربران این دو فیلم را توهین به شعور مخاطب و فریب دادن آنها می دانند. در ادامه به واکنش کاربران در توئیتر توجه فرمایید.</p>" +
            //"<p><strong>واکنش ها و انتقادات به فیلم «خانم یایا»:</strong></p>" +
            //"<p style=''text-align: right;''>در رابطه با فیلم ''خانم یایا'' آن چه بیش از هرچیز دیگر مخاطب را دچار شگفت زدگی می کند نام عبدالرضا کاهانی در مقام کارگردان این فیلم است؛ کارگردانی که سابقه ی ساخت چند فیلم خوب چون «بیست»، «هیچ» و «بیخود و بی جهت» را در کارنامه دارد. به نظر می رسد فیلم، اصلاً فیلمنامه ای ندارد، خبری از مولفه های ناب و شاخص سینمای کاهانی در آن دیده نمی شود، هیچ رگه ای از طنز و بامزگی در فیلم به چشم نمی خورد و فیلم عملاً فاقد منطق روایی ست.</p>" +
            //"<p><img class=''image_btn img-responsive-news'' style=''margin: 0px auto; display: block;'' title=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' src=''http://cdn.bartarinha.ir/files/fa/news/1397/8/24/1876002_596.jpg'' alt=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' width=''550'' height=''196'' align=''''></p>" +
            //"<p><img class=''image_btn img-responsive-news'' style=''margin: 0px auto; display: block;'' title=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' src=''http://cdn.bartarinha.ir/files/fa/news/1397/8/24/1876003_807.jpg'' alt=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' width=''550'' height=''738'' align=''''></p>" +
            //"<p><img class=''image_btn img-responsive-news'' style=''margin: 0px auto; display: block;'' title=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' src=''http://cdn.bartarinha.ir/files/fa/news/1397/8/24/1876004_652.jpg'' alt=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' width=''550'' height=''223'' align=''''></p>" +
            //"<p><img class=''image_btn img-responsive-news'' style=''margin: 0px auto; display: block;'' title=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' src=''http://cdn.bartarinha.ir/files/fa/news/1397/8/24/1876005_215.jpg'' alt=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' width=''550'' height=''231'' align=''''></p>" +
            //"<p><img class=''image_btn img-responsive-news'' style=''margin: 0px auto; display: block;'' title=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' src=''http://cdn.bartarinha.ir/files/fa/news/1397/8/24/1876006_341.jpg'' alt=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' width=''550'' height=''275'' align=''''></p>" +
            //"<p><img class=''image_btn img-responsive-news'' style=''margin: 0px auto; display: block;'' title=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' src=''http://cdn.bartarinha.ir/files/fa/news/1397/8/24/1876007_198.jpg'' alt=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' width=''550'' height=''524'' align=''''></p>" +
            //"<p><img class=''image_btn img-responsive-news'' style=''margin: 0px auto; display: block;'' title=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' src=''http://cdn.bartarinha.ir/files/fa/news/1397/8/24/1876008_696.jpg'' alt=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' width=''550'' height=''605'' align=''''></p>" +
            //"<p><img class=''image_btn img-responsive-news'' style=''margin: 0px auto; display: block;'' title=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' src=''http://cdn.bartarinha.ir/files/fa/news/1397/8/24/1876009_525.jpg'' alt=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' width=''550'' height=''221'' align=''''></p>" +
            //"<p><strong>واکنش ها و انتقادات به فیلم «لس آنجلس-تهران»:</strong></p>" +
            //"<p style=''text-align: right;''>لس آنجلس تهران صرفا یک فیلم کاملا تجاری ست که نداشتن فیلمنامه به آن آسیب رسانده است فیلم از جای نادرستی شروع می شود فصل شروع فیلم بسیار نامربوط و الکن است نریشن حرف هایی می زند که اساسا شبیه به لطیفه است و منطقی ندارد. لس آنجس تهران فیلم بازیگر و دیالوگ محور است.</p>" +
            //"<p style=''text-align: right;''>با دیدن این فیلم به نظر می رسد که پاکروان با یک طرح چند خطی و با استفاده ی ابزاری از پرستویی سراغ ساخت این فیلم رفته سعی کرده که فیلم کمدی بسازد اما فیلمش تبدیل به تصاویر بهم پیوسته شده، تصاویری که فارغ از منطق روایی به همدیگر وصله خورده چند بازیگر هم در قاب ها حضور دارند که می خواهند از هر طریقی خنده را به لب مخاطب بیاورند، اما مخاطبِ طفلک تا حدودی می تواند فرق کمدی بازی کردن یا دلقک بازی را تشخیص بدهد، خیراندیش یا پطروسیان یا مهناز افشار را کاری نداریم این بازیگران قبلا هم در چنین نقش های سخیفی بازی کردند اما پرویز پرستویی که ادعای خوانش دقیق فیلمنامه قبل از انتخاب نقش را دارد چرا به این ورطه ترسناک تن داده است؟</p>" +
            //"<p style=''text-align: right;''>مگر می شود پرستویی در فیلمی برقصد یا رپ بخواند؟ اصلا فیلمنامه یی وجود داشته که پرستویی آن را بخواند؟ در بعضی از سکانس ها به نظر می رسد از سر اجبار و تحمیل جلوی دوربین بازی می کند، چه گونه قبول کرده با همچین پارتنری(ژوبین رهبر) که الفبای بازیگری را نمی داند بازی کند؟&nbsp;</p>" +
            //"<p><strong><img class=''image_btn img-responsive-news'' style=''margin: 0px auto; display: block;'' title=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' src=''http://cdn.bartarinha.ir/files/fa/news/1397/8/24/1876013_696.jpg'' alt=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' width=''550'' height=''275'' align=''''></strong></p>" +
            //"<p><strong><img class=''image_btn img-responsive-news'' style=''margin: 0px auto; display: block;'' title=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' src=''http://cdn.bartarinha.ir/files/fa/news/1397/8/24/1876014_700.jpg'' alt=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' width=''550'' height=''281'' align=''''></strong></p>" +
            //"<p><strong><img class=''image_btn img-responsive-news'' style=''margin: 0px auto; display: block;'' title=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' src=''http://cdn.bartarinha.ir/files/fa/news/1397/8/24/1876015_713.jpg'' alt=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' width=''550'' height=''190'' align=''''></strong></p>" +
            //"<p><strong><img class=''image_btn img-responsive-news'' style=''margin: 0px auto; display: block;'' title=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' src=''http://cdn.bartarinha.ir/files/fa/news/1397/8/24/1876016_151.jpg'' alt=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' width=''550'' height=''164'' align=''''></strong></p>" +
            //"<p><strong><img class=''image_btn img-responsive-news'' style=''margin: 0px auto; display: block;'' title=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' src=''http://cdn.bartarinha.ir/files/fa/news/1397/8/24/1876017_794.jpg'' alt=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' width=''550'' height=''192'' align=''''></strong></p>" +
            //"<p><strong><img class=''image_btn img-responsive-news'' style=''margin: 0px auto; display: block;'' title=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' src=''http://cdn.bartarinha.ir/files/fa/news/1397/8/24/1876018_293.jpg'' alt=''ماجرای فحش خوریِ فرخ نژاد و پرستویی در سینماها'' width=''550'' height=''139'' align=''''></strong></p>          	</div>'";

            var txt = "<div class='panel'> 	<div class='sar_news_body'> 		<div class='row padd_news_gutter'> 			<div class='col-lg-7 col-md-5 col-sm-5 col-ms-8 col-xs-9'>                  					<div class='news_nav news_id_c'><i class='fa fa-newspaper-o fa-2x-newspaper'></i><span class='news_nav_title'> </span>۷۹۴۹۲۸</div> 				 			</div> 			<div class='col-lg-11 col-sm-13 col-ms-15 col-xs-19'>                  					<div class='news_nav news_pdate_c'><i class='fa fa-clock-o fa-2x-newspaper'></i><span class='news_nav_title'><div class='hidden-ms' style='display: inline;'></div> </span>۲۲ آبان ۱۳۹۷ - ۰۸:۳۰</div> 				 			</div> 			<div class='col-md-5 col-sm-5 col-xs-8'> 				<div class='news_nav news_hits'><i class='fa fa-eye fa-2x-eye'></i><span class='news_nav_title'> </span>۵۸۱۶&nbsp;<span class='hidden-xs'>بازدید</span> </div> 			</div> 			<div class='col-sm-4 hidden-ms hidden-xs'>                  					<div class='news_nav news_comments'> 						<i class='fa fa-comments-o fa-2x-comment-news'></i> 						<a href='/fa/news/794928/کلکسیون-خودرو&zwnj;های-لوکس-لیدی-گاگا#comments' target='_blank'>۸ نظر</a> 					</div>                  			</div> 			<div class='col-md-9 col-sm-9 col-ms-13 col-xs-36'>  				<div class='news_tools'> 					<a href='#' class='news_size_up'><i class='fa fa-plus-square fa-2x-plus'></i></a> 					<a href='#' class='news_size_reset'></a> 					<a href='#' class='news_size_down'><i class='fa fa-minus-square fa-2x-plus'></i></a> 					<a title='ذخیره' class='news_save_botton fa fa-save fa-2x-plus' href='/fa/save/794928'></a> 					<div title='ارسال به دوستان' class='news_emails_botton fa fa-envelope-o fa-2x-plus' onclick='window.open(&quot;/fa/send/794928&quot;, &quot;sendmailwin&quot;,&quot;left=200,top=100,width=370,height=400,toolbar=0,resizable=0,status=0,scrollbars=1&quot;);'></div> 					<div title='نسخه چاپی' class='print_ico fa fa-print fa-2x-plus' onclick='window.open(&quot;/fa/print/794928&quot;, &quot;printwin&quot;,&quot;left=200,top=200,width=820,height=550,toolbar=1,resizable=0,status=0,scrollbars=1&quot;);'></div> 					<div class='wrapper'></div> 				</div> 			</div> 		</div> 	</div> 	<div class='rutitr'></div> 	<div class='title' style='text-align:center;margin-bottom: 10px;margin-top: 4px;'> 		<h1 class='title Htag'> 			<a href='/fa/news/794928/کلکسیون-خودرو&zwnj;های-لوکس-لیدی-گاگا'> 				<i class='fa fa-title-bolet fa-caret-left'></i>                 کلکسیون خودرو&zwnj;های لوکس «لیدی گاگا» 			</a> 		</h1> 	</div>      		<div class='row'> 			<div class='col-md-36'> 				<div class='brd_subtitle'></div> 				<div class='subtitle'>                      					سلبریتی را سراغ نداریم که علاقه&zwnj;ای به خودنمایی و سوار شدن بر خودرو&zwnj;های خاص و گران&zwnj;قیمت نداشته باشد و از آنجایی که عشق خودرو مرد و زن نمی&zwnj;شناسد در کنار سلبریتی&zwnj;های مرد، سلبریتی&zwnj;های زن نیز علاقه زیادی به خودرو نشان می&zwnj;دهند و دوست دارند هر روز سوار بر یک خودروی جدید در خیابان&zwnj;ها جولان بدهند. 				</div> 			</div> 		</div>       	<div class='body body_media_content_show' style='text-align: justify;padding: 10px;'>         <p style='text-align: right;'><span style='color: #0000ff;'>برترین ها - ترجمه از محمد کاملان:</span> سلبریتی را سراغ نداریم که علاقه&zwnj;ای به خودنمایی و سوار شدن بر خودروهای خاص و گران&zwnj;قیمت نداشته باشد و از آنجایی که عشق خودرو مرد و زن نمی&zwnj;شناسد در کنار سلبریتی&zwnj;های مرد، سلبریتی&zwnj;های زن نیز علاقه زیادی به خودرو نشان می&zwnj;دهند و دوست دارند هر روز سوار بر یک خودروی جدید در خیابان&zwnj;ها جولان بدهند.</p>" +
"<p style='text-align: right;'>گاهی اوقات نیز سلبریتی&zwnj;ها خودروهای مورد علاقه خود را خریداری نمی&zwnj;کنند و از این خودروها برای تبلیغات کنسرت&zwnj;ها و برنامه&zwnj;های خود استفاده می&zwnj;کنند و آن&zwnj;ها را کنار می&zwnj;گذارند. اما از آنجایی که این خودروها در بیشتر مواقع ویژگی&zwnj;های خاصی دارد به راحتی نمی&zwnj;توان از کنار آن&zwnj;ها رد شد.</p>" +
"<p style='text-align: right;'>در نتیجه لیدی گاگا که یکی از سوپراستارترین چهره&zwnj;های دنیاست و در میان سلبریتی&zwnj;های زن ثروت و دارایی زیادی دارد خودروهای مختلفی را سوار می&zwnj;شود و از اینکه پول هنگفتی برای خرید و اجاره بهترین خودروهای دنیا خرج کند لذت می&zwnj;برد.</p>" +
"<p style='text-align: right;'>به همین دلیل قصد داریم در ادامه با هم نگاهی به خودروهای جذابی داشته باشیم که دل لیدی&zwnj; گاگا را برده&zwnj;اند.</p>" +
"<p style='text-align: right;'>سواری با یکی از خودروهای اختصاصی الویس&zwnj; پریسلی فقید</p>" +
"<p style='text-align: right;'>اگر از طرفداران لیدی گاگا باشید حتماً به خاطر دارید که حدود ۲ سال پیش تور بزرگی با نام Dive Bar راه&zwnj;اندازی کرد. این قسمتی از برنامه&zwnj; بزرگ تبلیغاتی لیدی گاگا جهت فورش آلبوم جدیدش با نام Joanne بود. در نتیجه لیدی گاگا هرچه در چنته داشت را در این تور به نمایش گذاشت.</p>" +
"<p style='text-align: right;'>یکی از جالب&zwnj;ترین موارد این تور حضور لیدی گاگا با خودروی کادیلاک کوپه دویل بود. این خودرو که در گذشته الویس پریسلی فقید سوار بر آن میشده است یکبار دیگر توانست یاد و خاطره این سلطان راک را در ذهن هواداران زنده کند و تبلیغ خوبی برای لیدی گاگا نیز به حساب می&zwnj;آمد. متأسفانه بخت با لیدی گاگا یار نبود و موفق به خرید این کادیلاک کلکسیونی محصول سال ۱۹۵۵ نشد و در نهایت شاهد فروش کادیلاک الویس در یک حراجی آنلاین بودیم.</p>" +
"<p style='text-align: right;'><strong><span style='font-size: 18pt;'>18. لامبورگینی هوراکان، خودرویی برازنده لیدی گاگا</span></strong></p>" +
"<p style='text-align: right;'><img class='image_btn img-responsive-news' style='margin: 0px auto; display: block;' title='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' src='http://cdn.bartarinha.ir/files/fa/news/1397/8/19/1869732_482.jpg' alt='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' width='550' height='367' align=''></p>" +
"<p style='text-align: right;'>لیدی گاگا خواننده محبوب نسل جوان است و جوانان و نوجوانان زیادی در سرتاسر دنیا هنر و سبک زندگی او را دنبال می&zwnj;کنند. در نتیجه باید رفتاری در خور جوان&zwnj;ها داشته باشد و به همین دلیل در کنار خودورهای کلاسیک و لاچکری، گاهی اوقات نیز با خودروهای مدرن و &zwnj;جوان&zwnj;پسند در خیابان ظاهر می&zwnj;شود تا خودی نشان دهد و ثابت کند که نبض جوانان را در دست دارد.</p>" +
"<p style='text-align: right;'>به همین دلیل در میان کلکسیون خودروهای لیدی گاگا یک لامبورگینی هوراکان مشکی به چشم می&zwnj;خورد، جالب است بدانید لیدی گاگا برای اجرای ترانه&zwnj;ای در مسابقه سوپربول که معروف&zwnj;ترین رویداد ورزشی آمریکا به حساب می&zwnj;آید با همین خودروی لامبورگینی هوراکان به استادیوم رفت.</p>" +
"<p style='text-align: right;'>واژه هوراکان در افسانه&zwnj;شناسی تمدن مایا به معنای خدای باد، توفان و آتش است و کاملاً مشخص است چنین خودرویی جایی بهتر از کلکسیون لیدی گاگا را پیدا نخواهد کرد.</p>" +
"<hr>" +
"<p style='text-align: right;'><strong><span style='font-size: 18pt;'>17. لیدی گاگا علاقه زیادی به پورشه&zwnj;&zwnj;سواری دارد</span></strong></p>" +
"<p style='text-align: right;'><img class='image_btn img-responsive-news' style='margin: 0px auto; display: block;' title='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' src='http://cdn.bartarinha.ir/files/fa/news/1397/8/19/1869733_748.jpg' alt='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' width='550' height='312' align=''></p>" +
"<p style='text-align: right;'>ارزش دارایی&zwnj;های لیدی گاگا ده&zwnj;ها میلیون دلار برآورد شده و از آنجایی که او هنوز در اوج جوانی است انتظار می&zwnj;رود در آینده دارایی&zwnj;های او بسیار بیشتر از این شود. در نتیجه کاملاً مشخص است این سلبریتی جوان و خوش آتیه دست روی هر خودرویی بگذارد آن را از آن خود می&zwnj;کند.</p>" +
"<p style='text-align: right;'>به همین دلیل است که هواداران او در مونترال شاهد سوار شدن لیدی گاگا به یک خودروی پورشه باکستر بودند. بدون شک این خودرو گران&zwnj;ترین خودروی حاضر در کلکسیون لیدی گاگا نیست اما پورشه&zwnj;سواری لطف دیگری دارد و بدون شک لیدی گاگا نخواسته کلکسیون خودروهای او بدون پورشه باشد.</p>" +
"<hr>" +
"<p style='text-align: right;'><span style='font-size: 18pt;'><strong>16. شورولت نوا برای هوادارانی که به خودروهای کلاسیک علاقه دارند</strong></span></p>" +
"<p style='text-align: right;'><img class='image_btn img-responsive-news' style='margin: 0px auto; display: block;' title='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' src='http://cdn.bartarinha.ir/files/fa/news/1397/8/19/1869734_152.jpg' alt='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' width='550' height='310' align=''></p>" +
"<p style='text-align: right;'>شورولت نوا یکی از نوستالژیک&zwnj;ترین خودورها است و مدل&zwnj;های اول آن در سال&zwnj;های ۱۹۶۱ تا ۱۹۸۸ تولید شده&zwnj;اند. این خودرو در میان ایرانی&zwnj;ها نیز شناخته شده است و چهارمین نسل آن توسط جنرال موتورز ایران عرضه شد.</p>" +
"<p style='text-align: right;'>لیدی گاگا نیز که به خودروهای کلاسیک و خاطره&zwnj;انگیز علاقه زیادی دارد یک شورولت نوا اس&zwnj;اس را به کلکسیون خود اضافه کرده است. از قرار معلوم لیدی گاگا علاقه زیادی به این خودرو دارد و عکس&zwnj;های زیادی را به همراه این خودرو در شبکه&zwnj;های اجتماعی منتشر کرد.</p>" +
"<hr>" +
"<p style='text-align: right;'><strong><span style='font-size: 18pt;'>15. لیدی گاگا و شورولت سیلورادو</span></strong></p>" +
"<p style='text-align: right;'><img class='image_btn img-responsive-news' style='margin: 0px auto; display: block;' title='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' src='http://cdn.bartarinha.ir/files/fa/news/1397/8/19/1869735_803.jpg' alt='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' width='550' height='423' align=''></p>" +
"<p style='text-align: right;'>با خودرویی طرف هستیم که با دنیای سینما غریبه نیست و در فیلم&zwnj;های مختلفی چشممان به جمال شورولت سیلورادو روشن شده است، یکی از معروف&zwnj;ترین این فیلم&zwnj;ها، بیل را بکش بود که در آن اوما ترومن هنرنمایی می&zwnj;کرد.</p>" +
"<p style='text-align: right;'>لیدی گاگا نیز که از قرار معلوم از طرفداران فیلم بیل را بکش است در موزیک ویدئوی ترانه «تلفن» در کنار بیانسه حضور پیدا کرد. این خودرو دقیقاً همان چیزی بود که در فیلم بیل را بکش استفاده شده بود. ظاهراً لیدی گاگا پس از سواری با این خودرو به کوئینتین تارانتینو پیشنهاد خرید آن را داده بود و از آنجایی که تارانتینو علاقه زیادی به این شورولت سیلورادو دارد این پیشنهاد را رد کرد.</p>" +
"<hr>" +
"<p style='text-align: right;'><span style='font-size: 18pt;'><strong>14. فورد برانکو، انتخاب لیدی گاگا برای روزهای گرم</strong></span></p>" +
"<p style='text-align: right;'><span style='font-size: 18pt;'><strong><img class='image_btn img-responsive-news' style='margin: 0px auto; display: block;' title='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' src='http://cdn.bartarinha.ir/files/fa/news/1397/8/19/1869736_926.jpg' alt='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' width='550' height='281' align=''></strong></span></p>" +
"<p style='text-align: right;'>یک بار دیگر لیدی گاگا سراغ یک خودروی قدیمی و کلاسیک را گرفت تا با استفاده از جذابیت&zwnj;های آن نظر هواداران را به خود جلب کند. لیدی گاگا این خودرو را برای روزهای گرم و آفتابی استفاده می&zwnj;کند و در موزیک ویدئوی Perfect Illusion نیز شاهد حضور فورد برانکو هستیم.</p>" +
"<hr>" +
"<p style='text-align: right;'><strong><span style='font-size: 18pt;'>13. لیدی گاگا سوار بر لینکلن کانتیننتال سال ۱۹۶۵</span></strong></p>" +
"<p style='text-align: right;'><strong><span style='font-size: 18pt;'><img class='image_btn img-responsive-news' style='margin: 0px auto; display: block;' title='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' src='http://cdn.bartarinha.ir/files/fa/news/1397/8/19/1869737_577.jpg' alt='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' width='550' height='367' align=''></span></strong></p>" +
"<p style='text-align: right;'>با نگاهی به کلکسیون خودروهای لیدی گاگا می&zwnj;توان به انتخاب این سلبریتی در خودروهای کلاسیک و قدیمی تبریک گفت چرا که کاملاً مشخص است لیدی گاگا در میان کلاسیک&zwnj;ترین خودروها گشته و بهترین آن&zwnj;ها را انتخاب کرده است.</p>" +
"<p style='text-align: right;'>یکی از این نمونه&zwnj;ها را می&zwnj;توان خودروی لینکلن کانتیننتال مدل ۱۹۶۵ دانست. این خودرو ممکن است قدیمی باشد اما تجهیزات داخلی اشرافی و لوکسی را در آن شاهد هستیم. یکی دیگر از ویژگی&zwnj;های جالب این لینکلن کانتیننتال صندلی&zwnj;های بزرگ و فضای جادار آن است تا دوستان و رفقای لیدی گاگا به راحتی در آنجا بگیرند و حسابی خوش بگذرانند.</p>" +
"<hr>-" +
"<p style='text-align: right;'><strong><span style='font-size: 18pt;'>12. شورولت ال&zwnj;کامینو،&zwnj; خودرویی قدرتمند برای لیدی گاگا</span></strong></p>" +
"<p style='text-align: right;'><strong><span style='font-size: 18pt;'><img class='image_btn img-responsive-news' style='margin: 0px auto; display: block;' title='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' src='http://cdn.bartarinha.ir/files/fa/news/1397/8/19/1869738_104.jpg' alt='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' width='550' height='309' align=''></span></strong></p>" +
"<p style='text-align: right;'>علاقه لیدی گاگا به خودروهای قدرمند بر کسی پوشیده نیست اما تجربه نشان داده است او خودروهایی را انتخاب می&zwnj;&zwnj;کند که در کنار قدرت، اصل و نسب داشته و قدیمی باشند. در این زمینه می&zwnj;توان به شورولت ال&zwnj;کامینو اشاره کرد.</p>" +
"<p style='text-align: right;'>لیدی گاگا بارها سوار بر این خودرو مشاهده شده و به اندازه&zwnj;ای به شولولت ال&zwnj;کامینو مشکی خود علاقه دارد که در موزیک ویدئو Joanne نیز از آن استفاده کرده است. انصافاً هم باید اعتراف کرد این خودرو با حال و هوای این موزیک ویدئو همخوانی خوبی دارد.</p>" +
"<hr>" +
"<p style='text-align: right;'><span style='font-size: 18pt;'><strong>11. مدلی کلاسیک از فورد موستانگ</strong></span></p>" +
"<p style='text-align: right;'><span style='font-size: 18pt;'><strong><img class='image_btn img-responsive-news' style='margin: 0px auto; display: block;' title='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' src='http://cdn.bartarinha.ir/files/fa/news/1397/8/19/1869739_957.jpg' alt='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' width='550' height='275' align=''></strong></span></p>" +
"<p style='text-align: right;'>لیدی گاگا در کنار فورد برانکو یک خودروی کلاسیک دیگر از برند فورد را نیز در کلکسیون خود دارد و یک از اولین مدل&zwnj;های فورد موستانگ را انتخاب کرده است تا گاراژ وی خالی از موستانگ نباشد.</p>" +
"<p style='text-align: right;'>این فورد موستانگ ظاهری شیک و کلاسیک دارد و خاطره&zwnj;های خوش ایام گذشته را در ذهن هواداران قدیمی لیدی گاگا تداعی می&zwnj;کند.</p>" +
"<hr>" +
"<p style='text-align: right;'><span style='font-size: 18pt;'><strong>10. مرسدس&zwnj;بنز </strong></span><span style='font-size: 18pt;'><strong>E350</strong></span></p>" +
"<p style='text-align: right;'><span style='font-size: 18pt;'><strong><img class='image_btn img-responsive-news' style='margin: 0px auto; display: block;' title='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' src='http://cdn.bartarinha.ir/files/fa/news/1397/8/19/1869740_684.jpg' alt='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' width='550' height='336' align=''></strong></span></p>" +
"<p style='text-align: right;'>سلبریتی را سراغ نداریم که یکی از مدل&zwnj;های مرسدس&zwnj;بنز را در کلکسیون خود نداشته باشد و لیدی گاگا نیز یک خودروی مرسدس&zwnj;بنز E350 را انتخاب کرده تا علاقه خود به برند بنز را ثابت کند. جالب است بدانید این مرسد&zwnj;س&zwnj;بنز، اولین خودرویی بود که لیدی گاگا رسما سوار بر آن شد و با آن تمرین&zwnj;های رانندگی را انجام داد تا نهایتاً به کمک همین خودرو گواهینامه&zwnj;اش را دریافت کند.</p>" +
"<p style='text-align: right;'>مرسدس&zwnj;بنز E350 خودروی شیک و اشرافی است که به لحاظ رانندگی نیز تجربه شیرین و لذت&zwnj;بخشی را در اختیار راننده قرار می&zwnj;دهد و به احتمال زیاد لیدی گاگا نیز این مرسدس&zwnj;بنز را به دلیل اینکه خودروی بسیار خوش&zwnj;فرمانی است انتخاب کرده تا راحت&zwnj;تر در آزمون رانندگی شرکت کند. البته پس از دریافت گواهینامه، کمتر لیدی گاگا سوار بر مرسدس&zwnj;بنز E350 مشاهده شده است.</p>" +
"<hr>" +
"<p style='text-align: right;'><strong><span style='font-size: 18pt;'>9. رولزرویس فانتوم سفید</span></strong></p>" +
"<p style='text-align: right;'><strong><span style='font-size: 18pt;'><img class='image_btn img-responsive-news' style='margin: 0px auto; display: block;' title='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' src='http://cdn.bartarinha.ir/files/fa/news/1397/8/19/1869741_255.jpg' alt='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' width='550' height='329' align=''></span></strong></p>" +
"<p style='text-align: right;'>لیدی گاگا در کنار یک رولزرویس فانتوم مشکی، مالک یک رولزرویس فانتوم سفید نیز هست. این خودرو طراحی ویژه&zwnj;ای دارد و امکانات داخلی آن ویژه&zwnj; و اختصاصی است. جذابیت&zwnj;های جالب این رولزرویس فانتوم بیشتر از چیزی است که در نگاه اول به نظر می&zwnj;رسد و تودوزی و صندلی&zwnj;های بسیار اشرافی و راحتی دارد.</p>" +
"<hr>" +
"<p style='text-align: right;'><strong><span style='font-size: 18pt;'>8. آئودی آر ۸</span></strong></p>" +
"<p style='text-align: right;'><img class='image_btn img-responsive-news' style='margin: 0px auto; display: block;' title='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' src='http://cdn.bartarinha.ir/files/fa/news/1397/8/19/1869742_596.jpg' alt='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' width='550' height='372' align=''></p>" +
"<p style='text-align: right;'>آئودی در کنار تمامی خودروهایی که سالانه عرضه می&zwnj;کند توجه ویژه&zwnj;ای به آئودی آر ۸ نشان داده و همین امر باعث محبوبیت ویژه این خودرو در بین سلبریتی&zwnj;ها شده است. آئودی آر ۸ به لحاظ طراحی و فنی شباهت&zwnj;هایی به لامبورگینی هوراکان دارد و همین موارد باعث شده تا این خودرو دل لیدی گاگا را ببرد و در کلکسیون خودروهای او شاهد مدلی جدید و پیشرفته از آئودی آر ۸ باشیم.</p>" +
"<p style='text-align: right;'>آئودی آر ۸ که لیدی گاگا سوار آن می&zwnj;شود دارای سیستم انتقال نیرو به چهار چرخ است و تجهیزات انتقال نیروی موتور به چرخ&zwnj;ها در این خودرو با لامبورگینی گالاردو و هوراکان یکی است تا در کنار طراحی و جذابیت، با یکی از سریع&zwnj;ترین خودروهای کلکسیون لیدی گاگا طرف باشیم.</p>" +
"<hr>" +
"<p style='text-align: right;'><span style='font-size: 18pt;'><strong>7. پونتیاک جی&zwnj;تی&zwnj;اُو برای خودنمایی بیشتر</strong></span></p>" +
"<p style='text-align: right;'><img class='image_btn img-responsive-news' style='margin: 0px auto; display: block;' title='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' src='http://cdn.bartarinha.ir/files/fa/news/1397/8/19/1869743_930.jpg' alt='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' width='550' height='259' align=''></p>" +
"<p style='text-align: right;'>در همین ابتدا باید اشاره کنیم که لیدی گاگا مالک پونتیاک جی&zwnj;تی&zwnj;اُو نیست اما در یکی از موزیک&zwnj; ویدئو&zwnj;های او شاهد سواری گرفتن لیدی گاگا از یک پونتیاک جی&zwnj;تی&zwnj;اُو بودیم. در این موزیک ویدئو لیدی گاگا با این پونیاک حسابی گرد و خاک به راه می&zwnj;اندازد و صحنه&zwnj;های جالبی را برای خودنمایی و ایجاد هیجان در مخاطب به نمایش می&zwnj;گذارد.</p>" +
"<p style='text-align: right;'>با توجه به علاقه لیدی گاگا به خودروهای کلاسیک و قدرتمند هیچ بعید نیز در آینده&zwnj;ای نزدیک لیدی گاگا یک پونتیاک جی&zwnj;تی&zwnj;اُ را نیز به کلکسیون خود اضافه کند.</p>" +
"<hr>" +
"<p style='text-align: right;'><strong><span style='font-size: 18pt;'>6. نهایت اصالت با مرسدس&zwnj;بنز W123</span></strong></p>" +
"<p style='text-align: right;'><img class='image_btn img-responsive-news' style='margin: 0px auto; display: block;' title='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' src='http://cdn.bartarinha.ir/files/fa/news/1397/8/19/1869744_944.jpg' alt='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' width='550' height='361' align=''></p>" +
"<p style='text-align: right;'>مرسدس&zwnj;بنز W123 یکی از آشناترین خودورهای بنز در میان ایرانیان است و تولید آن به سال&zwnj;های ۱۹۷۶ تا ۱۹۸۵ باز می&zwnj;گردد. جالب است بدانید مرسدس&zwnj;بنز W123 در کنار ایران، در سایر کشورها نیز فروش بسیار خوبی داشت و به&zwnj;عنوان موفق&zwnj;ترین محصول این برند آلمانی شناخته می&zwnj;شود.</p>" +
"<p style='text-align: right;'>جالب&zwnj;تر اینکه از قرار معلوم در گذشته شرایط ورود این خودرو برای دانشجویان ایرانی بسیار ساده و آسان بوده و به همین دلیل مرسدس بنز W123 در میان ایران&zwnj;ها با نام بنز دانشجویی نیز شناخته می&zwnj;شود.</p>" +
"<p style='text-align: right;'>این&zwnj;گونه که پیداست لیدی گاگا نیز به محبوبیت و دوام این مرسدس&zwnj;بنز زیبا و اصیل پی برده است و به همین دلیل یک دستگاه بنز W123 در کلکسیون خودروهای وی به چشم می&zwnj;خورد. مرسدس&zwnj;بنز W123 ممکن است گذشته خودروی جذابی بوده باشد اما برای دنیای امروز خودرویی معمولی است و به همین دلیل لیدی گاگا این خودرو را انتخاب کرده تا بدون اینکه شناخته شود به راحتی در خیابان&zwnj;ها تردد کند.</p>" +
"<hr>" +
"<p style='text-align: right;'><span style='font-size: 18pt;'><strong>5. فورد ۱۵۰ اس&zwnj;وی&zwnj;تی لایتنینگ</strong></span></p>" +
"<p style='text-align: right;'><img class='image_btn img-responsive-news' style='margin: 0px auto; display: block;' title='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' src='http://cdn.bartarinha.ir/files/fa/news/1397/8/19/1869745_526.jpg' alt='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' width='550' height='303' align=''>فورد ۱۵۰ اس&zwnj;وی&zwnj;تی لایتنینگ از آن دسته خودروهایی است که بعید به نظر می&zwnj;رسد در کلکسیون سایر سلبریتی&zwnj;ها حضور داشته باشد اما داستان لیدی گاگا فرق می&zwnj;کند و با سلبریتی&zwnj; طرف هستیم که به رفتار و سلیقه&zwnj;های غیر معمول معروف است.</p>" +
"<p style='text-align: right;'>لیدی گاگا به اندازه&zwnj;ای از فورد ۱۵۰ اس&zwnj;وی&zwnj;تی لایتنینگ سواری گرفته که حتی یک بار توسط پلیس با این خودرو جریمه نیز شده است.</p>" +
"<hr>" +
"<p style='text-align: right;'><strong><span style='font-size: 18pt;'>4. پونتیاک فایربرد ترنس&zwnj;ام</span></strong></p>" +
"<p style='text-align: right;'><strong><span style='font-size: 18pt;'><img class='image_btn img-responsive-news' style='margin: 0px auto; display: block;' title='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' src='http://cdn.bartarinha.ir/files/fa/news/1397/8/19/1869746_504.jpg' alt='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' width='550' height='316' align=''></span></strong></p>" +
"<p style='text-align: right;'>اگر نگاهی به سبک زندگی و همچنین اجراهای لیدی گاگا داشته باشید متوجه خواهید شد که او علاقه خاصی به رنگ مشکی دارد. به همین دلیل پونتیاک فایربرد ترنس&zwnj;ام با رنگ مشکی بسیاری جذابی را در موزیک ویدئو Marry the Night شاهد هستیم که لیدی گاگا سوار بر آن ترانه&zwnj;خوانی می&zwnj;کند.</p>" +
"<p style='text-align: right;'>این پونتیاک جذاب و پرابهت یکی دیگر از خودورهایی است که در مالکیت لیدی گاگا قرار ندارد اما با توجه به سابقه&zwnj;ای که از او سراغ داریم هیچ بعید نیست خبر خرید این خودرو را در آینده در رسانه&zwnj;ها شاهد باشیم.</p>" +
"<hr>" +
"<p style='text-align: right;'><span style='font-size: 18pt;'><strong>3. رولزرویس کورنیش ۳</strong></span></p>" +
"<p style='text-align: right;'><span style='font-size: 18pt;'><strong><img class='image_btn img-responsive-news' style='margin: 0px auto; display: block;' title='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' src='http://cdn.bartarinha.ir/files/fa/news/1397/8/19/1869747_169.jpg' alt='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' width='550' height='367' align=''></strong></span></p>" +
"<p style='text-align: right;'>عشق لیدی گاگا به خودروهای رولزرویس تمامی ندارد و یک مدل کلاسیک بسیار شیک از رولزرویس کورنیش ۳ را در اختیار داشت، لیدی گاگا سوار بر این خودرو در خیابان&zwnj;های شهر جولان می&zwnj;داد و مال و مکنت خود را به رخ هواداران می&zwnj;کشید تا اینکه در مراسم خیریه&zwnj;ای شرکت کرد و این رولزرویس دوست&zwnj;داشتنی را به نفع فقرا به فروش رساند.</p>" +
"<p style='text-align: right;'>رولزرویس کورنیش ۳ موتور قدرتمند ۶.۷۵ لیتری از نوع V8 دارد و به رغم اینکه یک خودروی دو در و جمع و جور است به&zwnj;عنوان یکی از سنگین&zwnj;وزن&zwnj;ترین خودروهای رولزرویس شناخته می شود.</p>" +
"<hr>" +
"<p style='text-align: right;'><span style='font-size: 18pt;'><strong>2. لیدی گاگا و عشق او به رولزرویس فانتوم</strong></span></p>" +
"<p style='text-align: right;'><span style='font-size: 18pt;'><strong><img class='image_btn img-responsive-news' style='margin: 0px auto; display: block;' title='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' src='http://cdn.bartarinha.ir/files/fa/news/1397/8/19/1869731_550.jpg' alt='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' width='550' height='312' align=''></strong></span></p>" +
"<p style='text-align: right;'>تجربه نشان داده است لیدی گاگا نه تنها به خودروهای کلاسیک و قدیمی علاقه نشان می&zwnj;دهد بلکه عشق شدیدی به خودروهای مدرن و لاچکری دارد. در این بین وقتی صحبت از لاکچری به میان می&zwnj;آید نامی مطرح&zwnj;تر از رولزرویس در دنیای خودرو سراغ نداریم.</p>-" +
"<p style='text-align: right;'>این امر باعث شده لیدی گاگا نه تنها یک خوروی رولزرویس فانتوم بلکه دو دستگاه از این خودروی زیبا و لاکچری را در اختیار داشته باشد. جالب است بدانید لیدی گاگا به&zwnj;اندازه&zwnj;ای به رولزرویس فانتوم علاقه دارد که ترجیح می&zwnj;دهد شخصاً پشت فرمان این خودروی افسانه&zwnj;ای بنشیند و همانند یک اشراف&zwnj;زاده با اصل و نسب در خیابان&zwnj;ها به گشت و گذار بپردازد و هوش از سر هواداران ببرد.</p>" +
"<hr>" +
"<p style='text-align: right;'><span style='font-size: 18pt;'><strong>1. لیدی گاگا سوار بر خودروی فرمول یک</strong></span></p>" +
"<p style='text-align: right;'><img class='image_btn img-responsive-news' style='margin: 0px auto; display: block;' title='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' src='http://cdn.bartarinha.ir/files/fa/news/1397/8/19/1869748_931.jpg' alt='نگاهی به خودروهای جذابی که دل لیدی گاگا را برده&zwnj;اند' width='550' height='429' align=''></p>" +
"<p style='text-align: right;'>بعید به نظر می&zwnj;رسد کسی عاشق خودرو باشد و سودای رانندگی خودروهای فرمول یک را در سر نداشته باشد اما رؤیا برای بسیاری از هواداران خودرو، خیالی بیش نیست و تا انتهای عمر قادر به رانندگی با این خودورها نیستند.</p>" +
"<p style='text-align: right;'>در این بین داستان لیدی گاگا فرق می&zwnj;کند و هر چیزی که بخواهد را به راحتی بدست می&zwnj;آورد. یکی از این موارد سواری با خودروهای فرمول یک است، از آنجایی که رانندگی با این خودروها نیاز به تخصص خاصی دارد لیدی گاگا از ماریو آندرتی، یکی از پیشکسوتان مسابقات فرمول یک درخواست می&zwnj;کند تا به همراه وی گشتی در پیست اتومبیل&zwnj;رانی بزنند.</p>" +
"<p style='text-align: right;'>در این قسمت به پایان فهرست خودروهایی رسیدیم که دل لیدی گاگا را برده&zwnj;اند، پیشنهاد&zwnj; می&zwnj;کنم اگر شما هم اخبار مربوط به لیدی گاگا را دنبال می&zwnj;کنید و اطلاعات جالبی از عشق لیدی گاگا به خودرو سراغ دارید در قسمت نظرات این موارد را با ما و سایر کاربران به اشتراک بگذارید.</p>          	</div>            		<div class='row' style='margin: 25px 0px;'> 			 			 	 	<div class='box'> 		 			<div style='text-align: justify; direction: rtl; padding: 5px 25px;'> 				<img src='http://cdn.bartarinha.ir/client/themes/fa/main/img/icon_ads.png' style='padding-left: 1px;' class='fr_img' width='20' height='19'> 				<a href='http://www.bartarinha.ir/fa/ads/redirect/ta/1504' target='_blank' class='title_adv' title='دانلود اپلیکیشن برترین ها ویژه اندروید'> 					دانلود اپلیکیشن برترین ها ویژه اندروید 				</a> 				<div class='wrapper'></div> 			</div> 		 			<div style='text-align: justify; direction: rtl; padding: 5px 25px;'> 				<img src='http://cdn.bartarinha.ir/client/themes/fa/main/img/icon_ads.png' style='padding-left: 1px;' class='fr_img' width='20' height='19'> 				<a href='http://www.bartarinha.ir/fa/ads/redirect/ta/1505' target='_blank' class='title_adv' title='دانلود اپلیکیشن برترین ها ویژه iOS'> 					دانلود اپلیکیشن برترین ها ویژه iOS 				</a> 				<div class='wrapper'></div> 			</div> 		 	</div>  		</div> 	       		<div class='row'> 			<div class='col-ms_36 col-sm-22 col-md-25 col-lg-21 col-lg-pull-8 col-md-pull-6 col-sm-pull-6 padd_main_r_new' style='margin-top: 20px; margin-bottom: 10px;'>                  	<div class='ads' style='display:block;'>  	<div style='padding-bottom:13px;'><a href='http://www.bartarinha.ir/fa/ads/redirect/a/2836' target='_blank'><img class='img-responsive' alt='' style='width:468px;height:60px;border:0px;' src='http://cdn.bartarinha.ir/files/adv/7415_628.png'></a></div> </div> 			</div> 		</div>      	<div class='wrapper'></div> 	<div class='col-xs-36' style='margin-bottom: 10px; padding: 0px 15px;'></div> 	<div class='wrapper'></div>       	<div class='tags_container'>  		<div class='tags_title'>  			<div class='col-xs-2 col-sm-5 col-md-5 col-lg-4'><div class='title_tag_1'><i class='fa fa-2x-share fa-tags'></i><div class='visible-lg visible-md visible-sm title_tag2_1'>برچسب ها:</div></div></div>  		<div class='col-xs-34 col-sm-31 col-md-31 col-lg-32'>  		<div class='title_tag_2'>  				  			<a href='/fa/tag/1/لیدی گاگا' class='tags_item'>لیدی گاگا</a>  			  			،  			  			  		  			<a href='/fa/tag/1/خودرو' class='tags_item'>خودرو</a>  			  			،  			  			  		  			<a href='/fa/tag/1/خودرو سلبریتی ها' class='tags_item'>خودرو سلبریتی ها</a>  			  			،  			  			  		  			<a href='/fa/tag/1/خودرو های جذاب' class='tags_item'>خودرو های جذاب</a>  			  			،  			  			  		  			<a href='/fa/tag/1/تکنولوژی' class='tags_item'>تکنولوژی</a>  			  			،  			  			  		  			<a href='/fa/tag/1/تکنولوژی خودرو' class='tags_item'>تکنولوژی خودرو</a>  			  			  		  		</div>    		</div>  		</div>  	</div>       <div class='share_cont'> 	<div class='row'> 		<div class='col-xs-24 col-sm-28 col-md-29'> 			<span> 			<i class='fa fa-2x-share fa-share-alt'></i> 				<div class='title_shareto'>اشتراک گذاری</div> 			</span> 			<div class='social_icons social_icons_display'> 				<a href='http://www.facebook.com/share.php?v=4&amp;src=bm&amp;u=http://bartarinha.ir/fa/news/794928/کلکسیون-خودرو&zwnj;های-لوکس-لیدی-گاگا&amp;t=کلکسیون خودرو&zwnj;های لوکس «لیدی گاگا»' rel='nofollow' target='_blank'><i class='fa fa-facebook-square fb-news'></i></a> 				<a href='https://plusone.google.com/_/+1/confirm?hl=en&amp;url=http://bartarinha.ir/fa/news/794928/کلکسیون-خودرو&zwnj;های-لوکس-لیدی-گاگا&amp;title=کلکسیون خودرو&zwnj;های لوکس «لیدی گاگا»' rel='nofollow' target='_blank'><i class='fa fa-google-plus-square gp-news'></i></a> 				<a href='http://www.twitter.com/home?status=کلکسیون خودرو&zwnj;های لوکس «لیدی گاگا» http://bartarinha.ir/fa/news/794928/کلکسیون-خودرو&zwnj;های-لوکس-لیدی-گاگا' rel='nofollow' target='_blank'><i class='fa fa-twitter-square twitter-news'></i></a> 				<a href='whatsapp://send?text=کلکسیون خودرو&zwnj;های لوکس «لیدی گاگا» http://bartarinha.ir/fa/news/794928/کلکسیون خودرو&zwnj;های لوکس «لیدی گاگا»' rel='nofollow' target='_blank'><i class='fa fa fa-whatsapp wt-news'></i></a> 				<a href='https://telegram.me/share/url?url=http://bartarinha.ir/fa/news/794928' target='_blank'><i class='fa fa-paper-plane telegram-news'></i></a> 			</div> 		</div> 		<div class='col-xs-12 col-sm-8 col-md-7' style='margin-top: 10px;'> 			<a title='Error Report' class='send_error_bot' onclick='window.open(&quot;/fa/report/794928&quot;, &quot;sendmailwin&quot;,&quot;left=200,top=100,width=450,height=400,toolbar=0,resizable=0,status=0,scrollbars=1&quot;);'>گزارش خطا</a> 		</div> 		  	</div> </div>  </div>";

            var doc = new HtmlDocument();
            doc.LoadHtml(txt);

            //به دست آوردن مقادیر تمامی ندهای پی
            var nodes = doc.DocumentNode.SelectNodes("//p");
            GossipSiteEntities context = new GossipSiteEntities();


            Post entity = new Post();


            //به دست آوردن تمامی پراپرتی های جدول پست
            var values = typeof(Post)
               .GetProperties()
               .Where(p => !p.PropertyType.IsClass || p.PropertyType == typeof(String))
               .Select(p => new { p.Name, Value = p.GetValue(entity, null) })
               .ToList();

            //---------------------------------------------------------------------------
            //ContentPost فیلتر پراپرتی ها بر اساس 
            var contentPosts = values.Where(p => p.Name.Contains("ContentPost"));

            foreach (var item in nodes)
            {
                if (item.InnerText.Trim() == "")
                    continue;

                foreach (var item_1 in contentPosts)
                {
                    var valueEntity = entity.GetType().GetProperty(item_1.Name).GetValue(entity);
                    if (valueEntity == null)
                    {
                        //تنظیم پراپرتی  جدول پست
                        //entity.Subject1 = ....
                        entity.GetType().GetProperty(item_1.Name).SetValue(entity, item.InnerText);

                        //با تنظیم مقدار هر پراپرتی  جدول پست از حلقه اول خارج می شویم
                        //و به دنبال پراپرتی بعدی برای تنظیم مقدار آن می رویم
                        break;
                    }
                }
            }

            //---------------------------------------------------------------------------

            //به دست آوردن مقادیر تمامی ندهای اسپن
            nodes = doc.DocumentNode.SelectNodes("//span");

            //Subject فیلتر پراپرتی ها بر اساس 
            var subjects = values.Where(p => p.Name.Contains("Subject") && !p.Name.Contains("Subject1") && !p.Name.Contains("SubSubject"));

            foreach (var item in nodes)
            {
                if (item.InnerText.Trim() == "")
                    continue;

                foreach (var item_1 in subjects)
                {
                    var valueEntity = entity.GetType().GetProperty(item_1.Name).GetValue(entity);
                    if (valueEntity == null)
                    {
                        //تنظیم پراپرتی  جدول پست
                        //entity.Subject1 = ....
                        entity.GetType().GetProperty(item_1.Name).SetValue(entity, item.InnerText);

                        //با تنظیم مقدار هر پراپرتی  جدول پست از حلقه اول خارج می شویم
                        //و به دنبال پراپرتی بعدی برای تنظیم مقدار آن می رویم
                        break;
                    }
                }
            }

            //---------------------------------------------------------------------------
            //به دست آوردن مقادیر تمامی ندهای اسپن
            nodes = doc.DocumentNode.SelectNodes("//img");

            //Image فیلتر پراپرتی ها بر اساس 
            var images = values.Where(p => p.Name.Contains("Image"));
            string urlImg = "";
            foreach (var item in nodes)
            {
                if (item.OuterHtml.Trim() == "")
                    continue;

                //چک کردن موجود بودن یو آر ال تصویر 
                var regMatch = Regex.Matches(item.OuterHtml, "http://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?.(?:jpg|bmp|gif|png)");
                if (regMatch != null)
                    urlImg = regMatch[0].Value;
                else
                    continue;

                    foreach (var item_1 in images)
                    {
                        var valueEntity = entity.GetType().GetProperty(item_1.Name).GetValue(entity);
                        if (valueEntity == null)
                        {
                            //تنظیم پراپرتی  جدول پست
                            //entity.Subject1 = ....
                            entity.GetType().GetProperty(item_1.Name).SetValue(entity, urlImg);

                            //با تنظیم مقدار هر پراپرتی  جدول پست از حلقه اول خارج می شویم
                            //و به دنبال پراپرتی بعدی برای تنظیم مقدار آن می رویم
                            break;
                        }
                    }
            }


            context.Posts.Add(entity);
            context.SaveChanges();

            return null;
        }

        //ایجاد صفحه اصلی
        private void CreateIndexPage(string path, PostManagement postManagement)
        {
            /////////////////////////////create bloglist/////////////////////////////
            var docIndex = new HtmlDocument();
            docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
            var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

            //حذف محتويات ند بلاك-author-grid
            postManagement.ClearContentNode(nodesIndex, "author-grid");

            //ایجاد  تگ آرتیکل به ازای هر پست
            var repo = new PostRepository();
            var postQuiz = repo.SelectPostUser().ToList();
            foreach (var item in postQuiz)
            {
                item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                //ايجاد محتوا براي وسط صفحه-- author-grid
                var itSelfNode = postManagement.CreateBloglist(item);
                if (itSelfNode != null)
                {
                    result = postManagement.AddHeadToContentDiv(nodesIndex, "author-grid", itSelfNode);
                }
            }

            try
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(result.OuterHtml);
                htmlDoc.Save(path + "/Views/Home/Index.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
            }

            //////////////////////Create catlist///////////////////////////////////////
            docIndex = new HtmlDocument();
            docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
            nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

            //حذف محتويات ند بلاك-catlist
            postManagement.ClearContentNode(nodesIndex, "tab-content");

            //ایجاد  محتواي تب هاي کت ليست
            repo = new PostRepository();
            postQuiz = repo.SelectPostUser().ToList();
            foreach (var item in postQuiz)
            {
                item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                //ايجاد محتوا براي قسمت طبقه بندی-- catlist
                var itSelfNode = postManagement.CreateCatListContent(item);
                if (itSelfNode != null)
                {
                    result = postManagement.AddHeadToContentDiv(nodesIndex, "tab-content", itSelfNode);
                }
            }

            try
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(result.OuterHtml);
                htmlDoc.Save(path + "/Views/Home/Index.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
            }

            //////////////////////Create bloglist-content///////////////////////////////////////
            docIndex = new HtmlDocument();
            docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
            nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

            //حذف محتويات ند بلاك-catlist
            postManagement.ClearContentNode(nodesIndex, "row bloglist-content");

            //ایجاد  محتواي تب هاي کت ليست
            repo = new PostRepository();
            postQuiz = repo.SelectPostUser().OrderBy(x => x.CommentCount).Take(7).ToList();
            foreach (var item in postQuiz)
            {
                item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                //ايجاد محتوا براي قسمت طبقه بندی-- catlist
                var itSelfNode = postManagement.CreateBloglistContent(item);
                if (itSelfNode != null)
                {
                    result = postManagement.AddHeadToContentDiv(nodesIndex, "row bloglist-content", itSelfNode);
                }
            }

            try
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(result.OuterHtml);
                htmlDoc.Save(path + "/Views/Home/Index.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
            }

            //////////////////////Create bloglist-default///////////////////////////////////////
            docIndex = new HtmlDocument();
            docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
            nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

            //حذف محتويات ند بلاك-catlist
            postManagement.ClearContentNode(nodesIndex, "bloglist default");

            //ایجاد  محتواي bloglist default
            repo = new PostRepository();
            postQuiz = repo.SelectPostUser().Take(5).ToList();
            foreach (var item in postQuiz)
            {
                item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                //ايجاد محتوا براي -- bloglist default
                var itSelfNode = postManagement.CreateBloglistDefault(item);
                if (itSelfNode != null)
                {
                    result = postManagement.AddHeadToContentDiv(nodesIndex, "bloglist default", itSelfNode);
                }
            }

            try
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(result.OuterHtml);
                htmlDoc.Save(path + "/Views/Home/Index.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
            }

            //////////////////////Create postslider-container slider-image-bottom///////////////////////////////////////
            docIndex = new HtmlDocument();
            docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
            nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

            //حذف محتويات ند بلاك-slider-image-bottom
            postManagement.ClearContentNode(nodesIndex, "sp-slides sp-slider-image");

            //ایجاد  محتواي slider-image-bottom
            repo = new PostRepository();
            postQuiz = repo.SelectPostUser().Take(7).ToList();
            foreach (var item in postQuiz)
            {
                item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                //ايجاد محتوا براي -- bloglist default
                var itSelfNode = postManagement.CreateSliderImageBottom(item);
                if (itSelfNode != null)
                {
                    result = postManagement.AddHeadToContentDiv(nodesIndex, "sp-slides sp-slider-image", itSelfNode);
                }
            }

            try
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(result.OuterHtml);
                htmlDoc.Save(path + "/Views/Home/Index.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
            }

            //////////////////////Create postslider-container slider-image-bottom sp-thumbnails sp-slider-image///////////////////////////////////////
            docIndex = new HtmlDocument();
            docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
            nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

            //حذف محتويات ند بلاك-slider-image-bottom
            postManagement.ClearContentNode(nodesIndex, "sp-thumbnails sp-slider-image");

            //ایجاد  محتواي slider-image-bottom
            repo = new PostRepository();
            postQuiz = repo.SelectPostUser().Take(7).ToList();
            foreach (var item in postQuiz)
            {
                item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                //ايجاد محتوا براي -- bloglist default
                var itSelfNode = postManagement.CreateSliderImageBottom_ImageBottom(item);
                if (itSelfNode != null)
                {
                    result = postManagement.AddHeadToContentDiv(nodesIndex, "sp-thumbnails sp-slider-image", itSelfNode);
                }
            }

            try
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(result.OuterHtml);
                htmlDoc.Save(path + "/Views/Home/Index.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
            }


            ////////////////////////sp-slides sp-slider-image-top///////////////////////////////////////
            docIndex = new HtmlDocument();
            docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
            nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

            //حذف محتويات ند
            postManagement.ClearContentNode(nodesIndex, "sp-slides sp-slider-image-top");

            //ایجاد  محتوا
            repo = new PostRepository();
            postQuiz = repo.SelectPostUser().OrderBy(x => x.PostID).Skip(7).Take(8).ToList();
            foreach (var item in postQuiz)
            {
                item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                //ايجاد محتوا براي
                var itSelfNode = postManagement.CreateSliderTop(item);
                if (itSelfNode != null)
                {
                    postManagement.AddHeadToContent(nodesIndex, "sp-slides sp-slider-image-top", itSelfNode);
                }
            }

            try
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(docIndex.DocumentNode.OuterHtml);
                htmlDoc.Save(path + "/Views/Home/Index.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
            }

            ////////////////////////sp-thumbnails sp-slider-image-top///////////////////////////////////////
            docIndex = new HtmlDocument();
            docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
            nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

            //حذف محتويات ند
            postManagement.ClearContentNode(nodesIndex, "sp-thumbnails sp-slider-image-top");

            //ایجاد  محتوا
            repo = new PostRepository();
            postQuiz = repo.SelectPostUser().OrderBy(x => x.PostID).Skip(7).Take(8).ToList();
            foreach (var item in postQuiz)
            {
                item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                //ايجاد محتوا براي
                var itSelfNode = postManagement.CreateSliderTopThumbnails(item);
                if (itSelfNode != null)
                {
                    postManagement.AddHeadToContent(nodesIndex, "sp-thumbnails sp-slider-image-top", itSelfNode);
                }
            }

            try
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(docIndex.DocumentNode.OuterHtml);
                htmlDoc.Save(path + "/Views/Home/Index.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
            }



            ////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////// sidebar-widget mostviewed///////////////////////////////////////
            docIndex = new HtmlDocument();
            docIndex.Load(path + "/Views/Shared/_Layout.cshtml", System.Text.Encoding.UTF8);
            nodesIndex = docIndex.DocumentNode.SelectNodes("//ul");

            ////حذف محتويات ند بلاك-slider-image-bottom
            postManagement.ClearContentNode(nodesIndex, "recent_posts_wid right-slider1");

            ////ایجاد  محتوا
            int rowID = 1;
            repo = new PostRepository();
            postQuiz = repo.SelectPostUser().OrderByDescending(p => p.Views).Take(5).ToList();
            foreach (var item in postQuiz)
            {
                item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                //ايجاد محتوا براي
                var itSelfNode = postManagement.CreatePostMostViewed(item, rowID);
                if (itSelfNode != null)
                {
                    postManagement.AddHeadToContent(nodesIndex, "recent_posts_wid right-slider1", itSelfNode);
                }
                rowID++;
            }

            try
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(docIndex.DocumentNode.OuterHtml);
                htmlDoc.Save(path + "/Views/Shared/_Layout.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
            }

            //////////////////////// sidebar-widget popular///////////////////////////////////////
            docIndex = new HtmlDocument();
            docIndex.Load(path + "/Views/Shared/_Layout.cshtml", System.Text.Encoding.UTF8);
            nodesIndex = docIndex.DocumentNode.SelectNodes("//ul");

            //حذف محتويات ند بلاك-slider-image-bottom
            postManagement.ClearContentNode(nodesIndex, "recent_posts_wid right-slider2");

            //ایجاد  محتوا
            rowID = 1;
            repo = new PostRepository();
            postQuiz = repo.SelectPostUser().OrderByDescending(x => x.LikePost).Take(5).ToList();
            foreach (var item in postQuiz)
            {
                item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                //ايجاد محتوا براي
                var itSelfNode = postManagement.CreatePostPopular(item, rowID);
                if (itSelfNode != null)
                {
                    postManagement.AddHeadToContent(nodesIndex, "recent_posts_wid right-slider2", itSelfNode);
                }
                rowID++;
            }

            try
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(docIndex.DocumentNode.OuterHtml);
                htmlDoc.Save(path + "/Views/Shared/_Layout.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
            }

            ////////////////////////// آخرين پست ها///////////////////////////////////////
            docIndex = new HtmlDocument();
            docIndex.Load(path + "/Views/Shared/_Layout.cshtml", System.Text.Encoding.UTF8);
            nodesIndex = docIndex.DocumentNode.SelectNodes("//ul");

            //حذف محتويات ند
            postManagement.ClearContentNode(nodesIndex, "superior-posts recent_posts_wid");

            //ایجاد  محتوا
            rowID = 1;
            repo = new PostRepository();
            postQuiz = repo.SelectPostUser().OrderByDescending(x => x.PostID).Take(6).ToList();
            foreach (var item in postQuiz)
            {
                item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                //ايجاد محتوا براي
                var itSelfNode = postManagement.CreatePostSuperiorr(item, rowID);
                if (itSelfNode != null)
                {
                    postManagement.AddHeadToContent(nodesIndex, "superior-posts recent_posts_wid", itSelfNode);
                }
                rowID++;
            }

            try
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(docIndex.DocumentNode.OuterHtml);
                htmlDoc.Save(path + "/Views/Shared/_Layout.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //ایجاد پست ها از جدول جدول پست به جدول پست
        public JsonResult CreatePost()
        {
            return null;
        }
    }
}
