import { useSelector } from 'react-redux';
import { CheckoutForm, SectionTitle, CartTotals } from '../components';
import { redirect } from 'react-router-dom';
import { toast } from 'react-toastify';

export const loader = (store) => () => {
  const user = store.getState().userState.user
  if(!user) {
    toast.warn('Please login to checkout...');
    return redirect('/login')
  }
  return null
}
const Checkout = () => {
  const cartTotal = useSelector((state) => state.cartState.cartTotal)
  if (cartTotal === 0) {
    return <SectionTitle text='Cart is empty...' />
  }
  return <>
    <SectionTitle text='Place your Order' />
    <div className="mt-8 grid gap-8 md:grid-cols-2 items-start">
      <CheckoutForm />
      <CartTotals />
    </div>
  </>
}

export default Checkout