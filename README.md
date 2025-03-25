# PizzaBookingApp

## Giới Thiệu Đề Tài

PizzaBookingApp là một ứng dụng web được phát triển với mục tiêu chính là cung cấp một cách dễ dàng và hiệu quả để đặt pizza trực tuyến. Ứng dụng này cho phép người dùng duyệt qua nhiều tùy chọn pizza, tùy chỉnh đơn đặt hàng của họ và thực hiện đặt chỗ một cách liền mạch.

## Công Nghệ Sử Dụng

- **C#**: Logic backend và phát triển API.
- **HTML**: Cấu trúc và thiết kế frontend.
- **CSS**: Định dạng và bố cục.
- **JavaScript**: Các phần tử và chức năng tương tác.
- **SQL**: Quản lý cơ sở dữ liệu.
- **ASP.NET Web API**: Framework web để xây dựng API.
- **Blazor page**: Framework cho việc xây dựng các trang web tương tác phía client.

## Các Tính Năng Tiêu Biểu

### Tính Năng Chung

- **Xác thực người dùng**:
  - Đăng nhập bằng tài khoản người dùng để truy cập vào hệ thống.
  - Cho phép người dùng đăng ký thông qua website.
  - Xác thực người dùng qua email.
  - Cho phép reset mật khẩu.
  - Cho phép đổi mật khẩu.
  - Phân quyền khác nhau cho khách hàng và admin.

- **Tính năng mua sắm**:
  - Cho phép người dùng xem danh sách sản phẩm.
  - Cho phép người dùng thêm sản phẩm vào giỏ hàng.
  - Tìm kiếm sản phẩm theo tên, danh mục.
  - Tính năng thanh toán đơn hàng.

### Tính Năng của Admin

- **Quản lý danh mục (category)**:
  - Thêm, sửa, xóa thông tin danh mục.
  - Hiển thị danh sách danh mục.
  - Tìm kiếm theo tên danh mục.

- **Quản lý sản phẩm (product)**:
  - Thêm, sửa, xóa thông tin sản phẩm.
  - Hiển thị danh sách sản phẩm.
  - Tìm kiếm theo tên sản phẩm.

- **Quản lý khách hàng (customer)**:
  - Hiển thị danh sách khách hàng.
  - Tìm kiếm khách hàng theo tên, số điện thoại hoặc địa chỉ.

- **Quản lý đơn đặt hàng (order)**:
  - Cho phép khách hàng đặt hàng và thanh toán.
  - Hiển thị danh sách các đơn đặt hàng đã được tạo cùng với trạng thái đơn hàng.
  - Xem chi tiết đơn đặt hàng.
  - Chỉnh sửa trạng thái đơn đặt hàng.

- **Báo cáo và thống kê**:
  - Hiển thị báo cáo số doanh thu theo tháng/năm.
  - Xem biểu đồ thể hiện doanh thu theo tháng/năm.

### Tính Năng Nâng Cao

- Website được triển khai theo mô hình web API. Phần client Single Page tạo cảm giác mượt hơn khi trải nghiệm.
- Có kiểm tra dữ liệu nhập vào.
- Sử dụng kỹ thuật debounce để cải thiện hiệu năng.
- Website reponsive có thể tương thích với nhiều kích thước màn hình.
- Sử dụng phương thức lưu trữ ở client để lưu trữ thông tin cần thiết của khách hàng.
- Xử lý route parameter để SEO (Tối ưu hóa công cụ tìm kiếm).
- Có chức năng chuyển theme (sáng/tối).

## Cách Chạy Dự Án

Để có một bản sao cục bộ và chạy được, hãy làm theo các bước đơn giản sau:

### Yêu Cầu Trước

- .NET SDK
- Visual Studio hoặc bất kỳ IDE C# nào khác
- SQL Server

### Cài Đặt

1. Clone repo
   ```sh
   git clone https://github.com/limbanga/PizzaBookingApp.git
   ```
2. Chuyển đến thư mục dự án
   ```sh
   cd PizzaBookingApp
   ```
3. Mở dự án trong IDE ưa thích của bạn (ví dụ: Visual Studio).
4. Khôi phục các gói NuGet
   ```sh
   dotnet restore
   ```
5. Cập nhật chuỗi kết nối cơ sở dữ liệu trong `appsettings.json`.
6. Chạy ứng dụng
   ```sh
   dotnet run
   ```

## Phần Demo

Bạn có thể xem bản demo của ứng dụng tại đây: [PizzaBookingApp Demo](https://drive.google.com/drive/folders/1XgMgY8oiDnMTyJifk4VBCyoVtoyGpuJ8?usp=sharing)




