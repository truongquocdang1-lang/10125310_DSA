using System;
using System.Text;

namespace BaiTapCayNhiPhan
{
    // Cấu trúc một nút trên cây nhị phân
    class Node
    {
        public int Data;
        public Node Left;
        public Node Right;

        public Node(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    class Program
    {
        // ============================================================
        // HÀM NHẬP CÂY NHỊ PHÂN BẰNG TAY (Đệ quy trái - phải)
        // ============================================================
        static Node NhapCay(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string input = (Console.ReadLine() ?? "").Trim();

                // Nhấn Enter (để trống) nghĩa là nhánh này không có nút
                if (string.IsNullOrEmpty(input))
                {
                    return null;
                }

                if (int.TryParse(input, out int giaTri))
                {
                    Node nut = new Node(giaTri);
                    nut.Left = NhapCay($" -> Nhập con TRÁI của {giaTri} (nhấn Enter nếu không có): ");
                    nut.Right = NhapCay($" -> Nhập con PHẢI của {giaTri} (nhấn Enter nếu không có): ");
                    return nut;
                }

                Console.WriteLine("   [!] Lỗi: Vui lòng nhập số nguyên hoặc nhấn Enter để bỏ qua.");
            }
        }

        // Hàm hỗ trợ: Nhập một số nguyên hợp lệ từ bàn phím
        static int NhapSoNguyen(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                if (int.TryParse(Console.ReadLine(), out int giaTri))
                {
                    return giaTri;
                }
                Console.WriteLine("   [!] Lỗi: Vui lòng nhập đúng định dạng số nguyên.");
            }
        }

        // Hàm hỗ trợ: Tìm một nút có giá trị x trên cây (dùng cho Bài tập 6)
        static Node TimNut(Node root, int x)
        {
            if (root == null) return null;
            if (root.Data == x) return root;

            Node trai = TimNut(root.Left, x);
            if (trai != null) return trai;

            return TimNut(root.Right, x);
        }

        // ============================================================
        // BÀI TẬP 1: Đếm số nút trên cây nhị phân
        // ============================================================
        static int DemSoNut(Node root)
        {
            if (root == null) return 0;
            return 1 + DemSoNut(root.Left) + DemSoNut(root.Right);
        }

        // ============================================================
        // BÀI TẬP 2: Tính tổng giá trị các nút trên cây nhị phân
        // ============================================================
        static int TongGiaTri(Node root)
        {
            if (root == null) return 0;
            return root.Data + TongGiaTri(root.Left) + TongGiaTri(root.Right);
        }

        // ============================================================
        // BÀI TẬP 3: Hiển thị giá trị các nút trên cây nhị phân
        // ============================================================
        static void HienThiTatCaNut(Node root)
        {
            if (root == null) return;
            Console.Write(root.Data + " ");
            HienThiTatCaNut(root.Left);
            HienThiTatCaNut(root.Right);
        }

        // ============================================================
        // BÀI TẬP 4: Hiển thị giá trị các nút có giá trị chẵn
        // ============================================================
        static void HienThiNutChan(Node root)
        {
            if (root == null) return;
            if (root.Data % 2 == 0)
            {
                Console.Write(root.Data + " ");
            }
            HienThiNutChan(root.Left);
            HienThiNutChan(root.Right);
        }

        // ============================================================
        // BÀI TẬP 5: Đếm số nút có giá trị chẵn trên cây nhị phân
        // ============================================================
        static int DemNutChan(Node root)
        {
            if (root == null) return 0;
            int dem = (root.Data % 2 == 0) ? 1 : 0;
            return dem + DemNutChan(root.Left) + DemNutChan(root.Right);
        }

        // ============================================================
        // BÀI TẬP 6: Đếm số con của một nút trên cây nhị phân
        // ============================================================
        // Cách 1: Đếm số con trực tiếp (0, 1 hoặc 2)
        static int DemSoConTrucTiep(Node p)
        {
            if (p == null) return 0;
            int dem = 0;
            if (p.Left != null) dem++;
            if (p.Right != null) dem++;
            return dem;
        }

        // Cách 2: Đếm toàn bộ nút con cháu bên dưới nút p
        static int DemTatCaConChau(Node p)
        {
            if (p == null) return 0;
            return DemSoNut(p) - 1;
        }

        // ============================================================
        // BÀI TẬP 7: Hiển thị giá trị các nút trên cây con trái
        // ============================================================
        static void HienThiCayConTrai(Node root)
        {
            if (root == null || root.Left == null)
            {
                Console.Write("Cây con trái rỗng!");
                return;
            }
            HienThiTatCaNut(root.Left);
        }

        // ============================================================
        // BÀI TẬP 8: Duyệt cây nhị phân theo các thứ tự
        // ============================================================
        // 1. Duyệt tiền thứ tự (NLR: Gốc - Trái - Phải)
        static void DuyetNLR(Node root)
        {
            if (root == null) return;
            Console.Write(root.Data + " ");
            DuyetNLR(root.Left);
            DuyetNLR(root.Right);
        }

        // 2. Duyệt trung thứ tự (LNR: Trái - Gốc - Phải)
        static void DuyetLNR(Node root)
        {
            if (root == null) return;
            DuyetLNR(root.Left);
            Console.Write(root.Data + " ");
            DuyetLNR(root.Right);
        }

        // 3. Duyệt hậu thứ tự (LRN: Trái - Phải - Gốc)
        static void DuyetLRN(Node root)
        {
            if (root == null) return;
            DuyetLRN(root.Left);
            DuyetLRN(root.Right);
            Console.Write(root.Data + " ");
        }

        // ============================================================
        // CHƯƠNG TRÌNH CHÍNH
        // ============================================================
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("=== NHẬP CÂY NHỊ PHÂN ===");
            Node root = NhapCay("Nhập giá trị nút GỐC (nhấn Enter nếu cây rỗng): ");

            if (root == null)
            {
                Console.WriteLine("\nCây rỗng, không có dữ liệu để xử lý!");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("\n================ KẾT QUẢ 8 BÀI TẬP ================");

            // Bài tập 1
            Console.WriteLine("Bài tập 1 - Số nút trên cây: " + DemSoNut(root));

            // Bài tập 2
            Console.WriteLine("Bài tập 2 - Tổng giá trị các nút: " + TongGiaTri(root));

            // Bài tập 3
            Console.Write("Bài tập 3 - Giá trị các nút trên cây: ");
            HienThiTatCaNut(root);
            Console.WriteLine();

            // Bài tập 4
            Console.Write("Bài tập 4 - Các nút có giá trị chẵn: ");
            if (DemNutChan(root) == 0)
                Console.Write("Không có nút chẵn nào");
            else
                HienThiNutChan(root);
            Console.WriteLine();

            // Bài tập 5
            Console.WriteLine("Bài tập 5 - Số nút có giá trị chẵn: " + DemNutChan(root));

            // Bài tập 6 (Nhập tay giá trị nút cần đếm con)
            int x = NhapSoNguyen("\nBài tập 6 - Nhập giá trị nút cần đếm số con: ");
            Node nutCanTim = TimNut(root, x);
            if (nutCanTim != null)
            {
                Console.WriteLine($"   => Nút {x} có {DemSoConTrucTiep(nutCanTim)} con trực tiếp (và tổng {DemTatCaConChau(nutCanTim)} nút con cháu).");
            }
            else
            {
                Console.WriteLine($"   => Không tìm thấy nút {x} trên cây.");
            }

            // Bài tập 7
            Console.Write("\nBài tập 7 - Các nút trên cây con trái của gốc: ");
            HienThiCayConTrai(root);
            Console.WriteLine();

            // Bài tập 8
            Console.WriteLine("Bài tập 8 - Duyệt cây theo các thứ tự:");
            Console.Write("   + Tiền thứ tự (NLR):  "); DuyetNLR(root); Console.WriteLine();
            Console.Write("   + Trung thứ tự (LNR): "); DuyetLNR(root); Console.WriteLine();
            Console.Write("   + Hậu thứ tự (LRN):   "); DuyetLRN(root); Console.WriteLine();

            Console.WriteLine("\nNhấn Enter để thoát...");
            Console.ReadLine();
        }
    }
}