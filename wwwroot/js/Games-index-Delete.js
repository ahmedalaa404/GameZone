$(document).ready(function () {

	$('.js-delete').on('click', function () {

		var Btn = $(this);
		const swalWithBootstrapButtons = Swal.mixin({
			customClass: {
				confirmButton: 'btn btn-danger mx-2',
				cancelButton: 'btn btn-light'
			},
			buttonsStyling: false
		})

		swalWithBootstrapButtons.fire({
			title: 'Are you sure That To Need Delete This Game?',
			text: "You won't be able to revert this!",
			icon: 'warning',
			showCancelButton: true,
			confirmButtonText: 'Yes, delete it!',
			cancelButtonText: 'No, cancel!',
			reverseButtons: true
		}).then((result) => {

			if (result.isConfirmed) {

				$.ajax({
					url: `/Games/Delete/${Btn.data('id')}`,
					method: 'Delete',
					success: function () {
						swalWithBootstrapButtons.fire(
							'Deleted!',
							'Game has been deleted.',
							'success'
						);
						Btn.parents('tr').fadeOut();

					},
					error: function () {
						swalWithBootstrapButtons.fire(
							'Error!',

						)
					}
				})

			}
		})









	});



})