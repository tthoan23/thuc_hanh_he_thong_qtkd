# Dàn ý quay demo tuần 05

Mục tiêu khoảng 4 phút 30 giây. Tự chạy các bước trước khi ghi hình và diễn giải theo cách bạn hiểu. Chuẩn bị sẵn terminal chạy API, Swagger, một cửa sổ `psql` và IDE. Nhập mật khẩu trước khi ghi hình.

1. **0:00 đến 0:30 · Giới thiệu.** Mở sơ đồ trong README, chỉ ra API dùng PostgreSQL và nêu hai endpoint cần demo.
2. **0:30 đến 1:40 · Mã nguồn.** Mở một controller và lần theo lời gọi đến `QtkdReadService`, `QtkdReadRepository` và `QtkdDbContext`. Giải thích lớp nào quyết định `404`, lớp nào tạo DTO và câu truy vấn chạy ở đâu.
3. **1:40 đến 2:40 · API chạy thật.** Mở Swagger, gọi `/api/customers` và `/api/contracts/1`. Chỉ vào `customerId: 1`, trạng thái `Draft` và `endDate: null`. Thử `/api/contracts/999999` để minh họa `404`.
4. **2:40 đến 3:55 · PostgreSQL.** Dùng các lệnh trong README để chỉ ra hai khóa ngoại và đối chiếu khách hàng, hợp đồng, bảng giá cùng hai mục giá. Nêu vai trò của `InitialCreate` và `HasData` trong lần cập nhật database đầu tiên.
5. **3:55 đến 4:30 · Kết thúc.** Tóm tắt phần đã chạy và điểm sẽ tiếp tục ở tuần 06. Trước khi kết thúc, kiểm tra đã hiển thị cả kết quả API và các dòng tương ứng trong PostgreSQL.

## Tự kiểm tra trước khi quay

- Khi gọi `GET /api/contracts/1`, thứ tự các lớp được gọi ra sao và lớp nào thực hiện truy vấn SQL?
- Vì sao `PriceItem` dùng cả `PriceListId` và `ServiceCode` làm khóa chính?
- Vì sao `endDate` có thể trống ở `Draft`? Nếu sửa tên khách hàng trong database, lời gọi GET kế tiếp sẽ trả về gì?

## Định dạng nộp

Quay video có tiếng, tối đa 5 phút, tên `mssv_th5.mp4`. File `mssv.zip` chứa hai mục `source/` và `mssv_th5.mp4` ở cấp gốc. File `mssv.txt` chứa link Google Drive của ZIP. Thay `mssv` bằng mã số sinh viên của bạn và duy trì quyền xem, tải ZIP trong suốt học kỳ.
