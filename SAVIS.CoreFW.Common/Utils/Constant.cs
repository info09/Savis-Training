using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NewCMS.Common
{
    public class ApplicationConstants
    {
        public const string APPLICATION_ID = "48ed5b71-66dc-4725-9604-4c042e45fa3f";
        public const string ADMINISTRATOR_USER_ID = "2fb87188-35b5-48d1-b527-58bf3a2b12b2";
        public const string ADMINISTRATOR_ROLES_ID = "e7b2c268-da31-41af-af78-dc5645e51b6d";
    }

    public class Constant
    {
        public const int StatusModifiedEnable = 1;
        public const int StatusModifiedDisable = 0;
        public const int StatusLock = 0;
        public const int StatusUnLock = 1;
        public const int StatusEnable = 1;
        public const int StatusDisable = 0;
        public const int StatusCommentEnable = 1;
        public const int StatusCommentDisable = 0;
        public const string Image = "Hình ảnh";

       

        public class Taxonomy
        {
            public const string PROGRAMME_CATEGORY = "PROGRAMME_CATEGORY";
        }

        public class TaxonomyVocabularies
        {
            public const string CHUYEN_MUC_TIN = "CHUYEN_MUC_TIN";
            public const string BAN_TIN_PHAT_SONG = "BAN_TIN_PHAT_SONG";
            public const string LINH_VUC_CHUONG_TRINH = "LINH_VUC_CHUONG_TRINH";
            public const string THE_LOAI_CHUONG_TRINH = "THE_LOAI_CHUONG_TRINH";
            public const string PTSX_XE = "PTSX_XE";
            public const string PTSX_MAYQUAY = "PTSX_MAYQUAY";
            public const string NGUONLUC_QUAYPHIM = "NGUONLUC_QUAYPHIM";
            public const string KHA_NANG_QUAY_PHIM = "KHA_NANG_QUAY_PHIM";
        }

        public class TaxonomyTerms
        {
            public const string CATEGORY_NEWS_1 = "Sự kiện VTV";
            public const string CATEGORY_NEWS_2 = "Thông tin nội bộ VTV24";
            public const string CATEGORY_NEWS_3 = "Lịch sự kiện";
            //term of BTPS
            public const string CATEGORY_BTPS_1 = "TCKD7h00";
            public const string CATEGORY_BTPS_2 = "TD10h15";
            public const string CATEGORY_BTPS_3 = "CĐ11h15";
            public const string CATEGORY_BTPS_4 = "TCKD12h30";
            public const string CATEGORY_BTPS_5 = "CĐ18h30";
            public const string CATEGORY_BTPS_6 = "QT00h05";
            //term of LVCT

            public const string CATEGORY_LVCT_1 = "Tài chính";
            public const string CATEGORY_LVCT_2 = "Giao thông";
            public const string CATEGORY_LVCT_3 = "Chính trị";


        }

        public class News
        {
            public class Status
            {
                public const string MOI_NHAP = "Mới nhập";
                public const string DA_XUAT_BAN = "Đã xuất bản";
            }
        }

        public class WorkflowDocumentType
        {
            public const string Storyline = "Storyline";
            public const string Advertisement = "Advertisement";


        }
    }

    public class DefaultMetadataConstants
    {
        public class Scene
        {
            public const string SCENE_FILE_PREFIX = "SCENE_FILE";
            public const string SCENE_THUMBNAIL_FILE_PREFIX = "SCENE_THUMBNAIL_FILE";

            public const string SCENE_META_START_TIME = "SYSTEM_SCENE_META_START_TIME";
            public const string SCENE_META_END_TIME = "SYSTEM_SCENE_META_END_TIME";
            public const string SCENE_META_VIEW_COUNT = "SYSTEM_SCENE_META_VIEW_COUNT";
            public const string SCENE_META_DOWNLOAD_COUNT = "SYSTEM_SCENE_META_DOWNLOAD_COUNT";

            public const string SCENE_META_ARCHIVE_STATUS = "SYSTEM_SCENE_META_ARCHIVE_STATUS";
            public const string SCENE_META_ARCHIVE_PROGRESS = "SYSTEM_SCENE_META_ARCHIVE_PROGRESS";
            public const string SCENE_META_ARCHIVE_MESSAGE = "SYSTEM_SCENE_META_ARCHIVE_MESSAGE";
        }

        public class File
        {
            public const string FILE_THUMBNAIL_FILE_PREFIX = "FILE_THUMBNAIL_FILE";
            public const string FILE_SOURCE_FILE_PREFIX = "FILE_SOURCE_FILE";

            public const string FILE_META_ARCHIVE_STATUS = "SYSTEM_FILE_META_ARCHIVE_STATUS";
            public const string FILE_META_ARCHIVE_PROGRESS = "SYSTEM_FILE_META_ARCHIVE_PROGRESS";
            public const string FILE_META_ARCHIVE_MESSAGE = "SYSTEM_FILE_META_ARCHIVE_MESSAGE";

            public const string FILE_META_TRANSCODE_DEFAULT_PROGRESS = "SYSTEM_FILE_META_TRANSCODE_DEFAULT_PROGRESS";
            public const string FILE_META_TRANSCODE_DEFAULT_MESSAGE = "SYSTEM_FILE_META_TRANSCODE_DEFAULT_MESSAGE";
            public const string FILE_META_TRANSCODE_DEFAULT_STATUS = "SYSTEM_FILE_META_TRANSCODE_DEFAULT_STATUS";

            public const string FILE_META_TRANSCODE_DEFAULT_JOBID = "SYSTEM_FILE_META_TRANSCODE_DEFAULT_JOBID";

            public const string FILE_META_VIEW_COUNT = "SYSTEM_FILE_META_VIEW_COUNT";
            public const string FILE_META_DOWNLOAD_COUNT = "SYSTEM_FILE_META_DOWNLOAD_COUNT";
        }

        public class Profile
        {
            public const string PROFILE_FILE_PREFIX = "PROFILE_FILE";
            public const string PROFILE_THUMBNAIL_FILE_PREFIX = "PROFILE_THUMBNAIL_FILE";
            public const string PROFILE_META_STATUS = "SYSTEM_PROFILE_META_STATUS";
            public const string PROFILE_META_PROGRESS = "SYSTEM_PROFILE_META_PROGRESS";
            public const string PROFILE_META_VIEW_COUNT = "SYSTEM_PROFILE_META_VIEW_COUNT";
            public const string PROFILE_META_DOWNLOAD_COUNT = "SYSTEM_PROFILE_META_DOWNLOAD_COUNT";
        }

        public class System
        {

            //public const string SYSTEM_SCENE_STATUS = "SYSTEM_SCENE_STATUS";
            //public const string SYSTEM_SCENE_PROGRESS = "SYSTEM_SCENE_PROGRESS";
            //public const string SYSTEM_SCENE_META_END_TIME = "SYSTEM_SCENE_META_END_TIME";
            //public const string SYSTEM_SCENE_META_START_TIME = "SYSTEM_SCENE_META_START_TIME";
        }

        public class UserProfile
        {
            public const string AVATAR = "AVATAR";
        }

        public class Status
        {
            public const string READ = "READ";
            public const string UNREAD = "UNREAD";
        }
    }

    public class FileTranscodeConstants
    {
        public const string FILE_READY = "READY";
        public const string FILE_PROCESSING = "PROCESSING";
        public const string FILE_FINISHED = "FINISHED";
    }

    public class FileArchiveStatusConstants
    {
        public const string UNARCHIVED = "NOT_ARCHIVED";
        public const string ARCHIVED = "ARCHIVED";
        public const string ERROR = "ERROR";
        public const string ARCHIVING = "ARCHIVING";

    }
}
